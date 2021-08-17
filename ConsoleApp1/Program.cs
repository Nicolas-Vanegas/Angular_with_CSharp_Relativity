using ConsoleApp1.DataProvider;
using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Domain.DomainNet;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.RepositoryNet;
using ConsoleApp1.RepositoryNet.Inferfaces;
using ConsoleApp1.RepositoryRest;
using ConsoleApp1.Utils;
using SimpleInjector;

namespace ConsoleApp1
{
    public class Program
    {
        static int _savedSearchId = 1047249;
        static void Main(string[] args)
        {
            //REST
            //HttpClientRepository httpClient = new HttpClientRepository();
            //InstanceSettingRestRepository instanceSettingRestRepository = new InstanceSettingRestRepository(httpClient);
            //DocumentsRestRepository documentsRestRepository = new DocumentsRestRepository(httpClient);
            //WordsRepository wordsRepository = new WordsRepository();
            //InstanceSettingObject instanceSettingObject = new InstanceSettingObject()
            //{
            //    Name = "Example 18 Rest",
            //    Value = 10,
            //    InitialValue = 10,
            //    Description = "Onboarding Description",
            //    Section = "Onboarding Section"
            //};
            //var pdfDocumentIds = documentsRestRepository.Documents(_savedSearchId);
            //var instanceSettingIdRest = instanceSettingRestRepository.CreateInstanceSetting(instanceSettingObject);
            //var wordLengthRest = instanceSettingRestRepository.GetInstanceSettingValue(instanceSettingIdRest);
            //var documentTextsRest = documentsRestRepository.DocumentTexts(pdfDocumentIds);
            //var filteredWordsRest = wordsRepository.filteredWords(documentTextsRest, wordLengthRest, false);

            //Net
            net();
        }
        public static void net()
        {
            var connection = new ServicesMgr();
            var container = new Container();
            var lifestyle = Lifestyle.Singleton;
            container.Register<IStartNetService, StartNetService>(lifestyle);
            container.Register<IInstanceSettingNetService, InstanceSettingNetService>(lifestyle);
            container.Register<IDocumentNetService, DocumentService>(lifestyle);
            container.Register<IInstanceSettingNetDataProvider, InstanceSettingNetDataProvider>(lifestyle);
            container.Register<IDocumentNetDataProvider, DocumentNetDataProvider>(lifestyle);
            container.Register<IDocumentsNetRepository, DocumentsNetRepository>(lifestyle);
            container.Register<IInstanceSettingsNetRepository, InstanceSettingNetRepository>(lifestyle);
            container.Register<IWords, Words>(lifestyle);

            var BL = container.GetInstance<IStartNetService>();
            BL.startApplication();
        }
    }
}
