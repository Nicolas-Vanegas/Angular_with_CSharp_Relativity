using ConsoleApp1.DataProvider;
using ConsoleApp1.DataProvider.DataProviderNet;
using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.DataProvider.DataProviderRest;
using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Domain.DomainNet;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Domain.DomainRest;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.Repositories.RepositoriesNet;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using ConsoleApp1.Repositories.RepositoriesRest;
using ConsoleApp1.Repositories.RepositoriesRest.Interfaces;
using ConsoleApp1.RepositoryNet;
using ConsoleApp1.RepositoryNet.Inferfaces;
using ConsoleApp1.RepositoryRest;
using ConsoleApp1.RepositoryRest.Interfaces;
using ConsoleApp1.Utils;
using SimpleInjector;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            net();
            rest();
        }
        public static void net()
        {
            var container = new Container();
            var lifestyle = Lifestyle.Singleton;
            container.Register<IStartNetService, StartNetService>(lifestyle);
            container.Register<IInstanceSettingNetService, InstanceSettingNetService>(lifestyle);
            container.Register<IDocumentNetService, DocumentService>(lifestyle);
            container.Register<IObjectTypeNetService, ObjectTypeNetService>(lifestyle);
            container.Register<IFieldNetService, FieldNetService>(lifestyle);
            container.Register<IFieldRestService, FieldRestService>(lifestyle);
            container.Register<IWordFoundNetService, WordFoundNetService>(lifestyle);
            container.Register<IInstanceSettingNetDataProvider, InstanceSettingNetDataProvider>(lifestyle);
            container.Register<IDocumentNetDataProvider, DocumentNetDataProvider>(lifestyle);
            container.Register<IObjectTypeNetDataProvider, ObjectTypeNetDataProvider>(lifestyle);
            container.Register<IFieldNetDataProvider, FieldNetDataProvider>(lifestyle);
            container.Register<IFieldRestDataProvider, FieldRestDataProvider>(lifestyle);
            container.Register<IWordFoundNetDataProvider, WordFoundNetDataProvider>(lifestyle);
            container.Register<IDocumentsNetRepository, DocumentsNetRepository>(lifestyle);
            container.Register<IInstanceSettingsNetRepository, InstanceSettingNetRepository>(lifestyle);
            container.Register<IObjectTypeNetRepository, ObjectTypeNetRepository>(lifestyle);
            container.Register<IFieldNetRepository, FieldNetRepository>(lifestyle);
            container.Register<IFieldRestRepository, FieldRestRepository>(lifestyle);
            container.Register<IWordFoundNetRepository, WordFoundNetRepository>(lifestyle);
            container.Register<IWords, Words>(lifestyle);

            var BL = container.GetInstance<IStartNetService>();
            BL.startApplication();
        }
        public static void rest()
        {
            var container = new Container();
            var lifestyle = Lifestyle.Singleton;
            container.Register<HttpClientConnection, HttpClientConnection>(lifestyle);
            container.Register<IStartRestService, StartRestService>(lifestyle);
            container.Register<IInstanceSettingRestService, InstanceSettingRestService>(lifestyle);
            container.Register<IDocumentRestService, DocumentRestService>(lifestyle);
            container.Register<IObjectTypeRestService, ObjectTypeRestService>(lifestyle);
            container.Register<IFieldNetService, FieldNetService>(lifestyle);
            container.Register<IFieldRestService, FieldRestService>(lifestyle);
            container.Register<IWordFoundNetService, WordFoundNetService>(lifestyle);
            container.Register<IInstanceSettingRestDataProvider, InstanceSettingRestDataProvider>(lifestyle);
            container.Register<IDocumentRestDataProvider, DocumentRestDataProvider>(lifestyle);
            container.Register<IObjectTypeRestDataProvider, ObjectTypeRestDataProvider>(lifestyle);
            container.Register<IFieldNetDataProvider, FieldNetDataProvider>(lifestyle);
            container.Register<IFieldRestDataProvider, FieldRestDataProvider>(lifestyle);
            container.Register<IWordFoundNetDataProvider, WordFoundNetDataProvider>(lifestyle);
            container.Register<IDocumentsRestRepository, DocumentsRestRepository>(lifestyle);
            container.Register<IObjectTypeRestRepository, ObjectTypeRestRepository>(lifestyle);
            container.Register<IInstanceSettingRestRepository, InstanceSettingRestRepository>(lifestyle);
            container.Register<IFieldNetRepository, FieldNetRepository>(lifestyle);
            container.Register<IFieldRestRepository, FieldRestRepository>(lifestyle);
            container.Register<IWordFoundNetRepository, WordFoundNetRepository>(lifestyle);
            container.Register<IWords, Words>(lifestyle);

            var BL = container.GetInstance<IStartRestService>();
            BL.startApplication();
        }
    }
}
