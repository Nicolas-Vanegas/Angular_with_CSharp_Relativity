using RelCustomPage.ActionResults;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RelCustomPage
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    [DebuggerStepThrough]
    public class SimpleInjectorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var mp = MiniProfiler.Current;
            if (mp != null)
            {
                var instances = SimpleInjectorMiniProfiler.GetResolvedItemsForCurrentRequest();

                var time = instances.Sum(x => x.Duration);
                var sb = new StringBuilder();
                foreach (var i in instances)
                {
                    sb.AppendLine(i.Duration + "\t" + i.Lifestyle + "\t" + i.Service + "\t" + i.Implementation);
                    sb.AppendLine(new string('-', 50));
                    sb.AppendLine(i.Graph);
                    sb.AppendLine();
                    sb.AppendLine();
                }

                mp.Head.AddCustomTiming("Resolve", new CustomTiming(mp, sb.ToString(), null)
                {
                    DurationMilliseconds = time,
                    ExecuteType = "Resolve"
                });

            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ProfilingActionFilter : ActionFilterAttribute
    {
        private const string StackKey = "ProfilingActionFilterStack";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var mp = MiniProfiler.Current;
            var items = actionContext.Request.Properties;
            if (mp != null)
            {
                if (!items.ContainsKey(StackKey))
                {
                    items.Add(StackKey, new Stack<IDisposable>());
                }
                var stack = items[StackKey] as Stack<IDisposable>;
                var area = actionContext.RequestContext.RouteData.Values.TryGetValue("area", out object areaToken)
                    ? areaToken as string + "."
                    : null;

                var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
                var actionName = actionContext.ActionDescriptor.ActionName;
                stack.Push(mp.Step($"Controller: {area}{controllerName}.{actionName}"));
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var items = actionExecutedContext.Request.Properties;
            if (items.ContainsKey(StackKey) && items[StackKey] is Stack<IDisposable> stack && stack.Count > 0)
            {
                stack.Pop().Dispose();
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
