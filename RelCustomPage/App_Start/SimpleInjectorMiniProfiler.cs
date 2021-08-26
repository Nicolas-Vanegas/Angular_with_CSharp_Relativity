using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace RelCustomPage.ActionResults
{
    public class SimpleInjectorMiniProfiler
    {
        public class ResolvedInstance
        {
            public string Service { get; set; }
            public string Implementation { get; set; }
            public string Lifestyle { get; set; }
            public string Graph { get; set; }
            public long Duration { get; set; }
        }
        private static readonly ConditionalWeakTable<HttpContext, List<InitializationData>> ResolvedInstances =
    new ConditionalWeakTable<HttpContext, List<InitializationData>>();
        private static readonly ConditionalWeakTable<HttpContext, List<InstanceInitializationData>> CreatedInstances =
            new ConditionalWeakTable<HttpContext, List<InstanceInitializationData>>();
        private static readonly ConcurrentDictionary<InstanceProducer, string> ObjectGraphs =
            new ConcurrentDictionary<InstanceProducer, string>();

        private static Type GetServiceType(InitializationContext context) =>
    context.Producer?.ServiceType ?? context.Registration.ImplementationType;

        private static string VisualizeObjectGraph(InstanceProducer producer) =>
    ObjectGraphs.GetOrAdd(producer, p => p.VisualizeObjectGraph());

        public static void RegisterContainerTracking(Container container)
        {
            container.Options.RegisterResolveInterceptor(CollectResolvedInstance, (ic) => true);
            container.RegisterInitializer(CollectCreatedInstance, (ic) => true);
        }
        private static object CollectResolvedInstance(InitializationContext context, Func<object> instanceProducer)
        {
            var watch = Stopwatch.StartNew();
            object instance = instanceProducer();
            watch.Stop();
            GetListForCurrentRequest(ResolvedInstances).Add(new InitializationData(context, instance, watch.ElapsedMilliseconds));
            return instance;
        }
        private static void CollectCreatedInstance(InstanceInitializationData instance)
        {
            GetListForCurrentRequest(CreatedInstances).Add(instance);
        }


        public static IEnumerable<ResolvedInstance> GetResolvedItemsForCurrentRequest()
        {
            return (
                from data in GetListForCurrentRequest(ResolvedInstances)
                select new ResolvedInstance
                {
                    Service = GetServiceType(data.Context).ToFriendlyName(),
                    Implementation = data.Context.Registration.ImplementationType.ToFriendlyName(),
                    Lifestyle = data.Context.Registration.Lifestyle.Name,
                    Graph = VisualizeObjectGraph(data.Context.Producer),
                    Duration = data.Duration
                })
                .ToArray();
        }

        public static List<T> GetListForCurrentRequest<T>(ConditionalWeakTable<HttpContext, List<T>> dictionary)
        {
            HttpContext currentRequest = HttpContext.Current;

            if (currentRequest == null)
            {
                return new List<T>();
            }

            lock (dictionary)
            {
                List<T> currentRequestInstances;

                if (!dictionary.TryGetValue(currentRequest, out currentRequestInstances))
                {
                    dictionary.Add(currentRequest,
                        currentRequestInstances = new List<T>(capacity: 32));
                }

                return currentRequestInstances;
            }
        }

        private struct InitializationData
        {
            public readonly InitializationContext Context;
            public readonly object Instance;
            public readonly long Duration;

            public InitializationData(InitializationContext context, object instance, long duration)
            {
                this.Context = context;
                this.Instance = instance;
                this.Duration = duration;
            }
        }
    }
}
