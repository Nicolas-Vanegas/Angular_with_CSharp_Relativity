using Castle.DynamicProxy;
using ConsoleApp1;
using ConsoleApp1.DataProvider;
using ConsoleApp1.DataProvider.DataProviderNet;
using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Domain.DomainNet;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Repositories.RepositoriesNet;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using ConsoleApp1.RepositoryNet;
using ConsoleApp1.RepositoryNet.Inferfaces;
using ConsoleApp1.RepositoryRest;
using ConsoleApp1.Utils;
using Relativity.API;
using RelCustomPage.ActionResults;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace RelCustomPage.App_Start
{
    public static class ContainerConfig
    {
        internal class WebApiInjectionLifestyle : ILifestyleSelectionBehavior
        {
            public Lifestyle SelectLifestyle(Type implementationType)
            {
                return Lifestyle.Scoped;
            }
        }
        #region MiniProfiler
        public class MiniProfierInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                var method = invocation.GetConcreteMethod();
                using (MiniProfiler.Current.Step($"{method.ReflectedType.Name.Replace("Repository", "Repo")}.{method.Name}"))
                {
                    invocation.Proceed();
                    try
                    {

                        if (IsIEnumerable(invocation.ReturnValue) && !IsList(invocation.ReturnValue))
                        {
                            var gType = invocation.ReturnValue.GetType().GetGenericArguments().Last();
                            var toListMethod = typeof(Enumerable).GetMethods()
                                .Where(m => m.Name == nameof(Enumerable.ToList))
                                .First(m => m.IsGenericMethod);
                            var listMethod = toListMethod.MakeGenericMethod(gType);
                            var result = listMethod.Invoke(null, new[] { invocation.ReturnValue });
                            invocation.ReturnValue = result;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            private bool IsIEnumerable(object variable)
            {
                if (variable != null)
                {
                    if (variable.GetType().GetInterfaces().Any(
                            i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IEnumerable<>)) && variable.GetType().GetGenericArguments().Any())
                    {
                        return true;
                    }
                }
                return false;
            }


            private bool IsList(object variable)
            {
                if (variable != null)
                {
                    if (variable.GetType().GetInterfaces().Any(
                            i => i.IsGenericType &&
                            (i.GetGenericTypeDefinition() == typeof(IList<>))
                            && variable.GetType().GetGenericArguments().Any()))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        #endregion

        public static Container ConfigureContainer(this HttpConfiguration config)
        {

            var container = GetContainer(() => HelperFactory.GetHelper());

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container, DependencyResolverScopeOption.RequiresNew);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }

        private static Container _container;
        private static readonly object @lock = new { };

        public static Container GetContainer(Func<ICPHelper> helperFactory)
        {

            if (_container == null)
            {
                lock (@lock)
                {
                    if (_container == null)
                    {
                        _container = GetContainerInternal(helperFactory);
#if DEBUG
                        SetupMiniProfiler(_container);
#endif
                    }
                }
            }
            return _container;
        }

        internal static Container GetContainerInternal(Func<ICPHelper> helperFactory)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.LifestyleSelectionBehavior = new WebApiInjectionLifestyle();
            container.Register(() => helperFactory());
            container.Register<IHelper>(() => container.GetInstance<ICPHelper>());

            container.Register<IDocumentNetService, DocumentService>();
            container.Register<IFieldNetService, FieldNetService>();
            container.Register<IInstanceSettingNetService, InstanceSettingNetService>();
            container.Register<IObjectTypeNetService, ObjectTypeNetService>();
            container.Register<IStartNetService, StartNetService>();
            container.Register<IWordFoundNetService, WordFoundNetService>();
            container.Register<IInstanceSettingNetDataProvider, InstanceSettingNetDataProvider>();
            container.Register<IDocumentNetDataProvider, DocumentNetDataProvider>();
            container.Register<IObjectTypeNetDataProvider, ObjectTypeNetDataProvider>();
            container.Register<IFieldNetDataProvider, FieldNetDataProvider>();
            container.Register<IWordFoundNetDataProvider, WordFoundNetDataProvider>();
            container.Register<IDocumentsNetRepository, DocumentsNetRepository>();
            container.Register<IInstanceSettingsNetRepository, InstanceSettingNetRepository>();
            container.Register<IObjectTypeNetRepository, ObjectTypeNetRepository>();
            container.Register<IFieldNetRepository, FieldNetRepository>();
            container.Register<IWordFoundNetRepository, WordFoundNetRepository>();
            container.Register<IWords, Words>();

            container.Register(() => container.GetInstance<ICPHelper>().GetAuthenticationManager());
            container.Register(() => container.GetInstance<ICPHelper>().GetCSRFManager());

            return container;
        }

        private static void SetupMiniProfiler(Container container)
        {
            SimpleInjectorMiniProfiler.RegisterContainerTracking(container);
        }


    }
}
