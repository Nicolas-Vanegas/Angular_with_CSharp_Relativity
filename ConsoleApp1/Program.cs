using ConsoleApp1.RepositoryNet;
using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1
{
    public class Program
    {
        static int _savedSearchId = 1047249;

        static void Main(string[] args)
        {
            //REST
            HttpClientRepository httpClient = new HttpClientRepository();
            InstanceSettingRestRepository instanceSettingRestRepository = new InstanceSettingRestRepository(httpClient);
            DocumentsRestRepository documentsRestRepository = new DocumentsRestRepository(httpClient);
            WordsRepository wordsRepository = new WordsRepository();
            InstanceSettingObject instanceSettingObject = new InstanceSettingObject()
            {
                Name = "Example 18 Rest",
                Value = 10,
                InitialValue = 10,
                Description = "Onboarding Description",
                Section = "Onboarding Section"
            };
            var pdfDocumentIds = documentsRestRepository.Documents(_savedSearchId);
            var instanceSettingIdRest = instanceSettingRestRepository.CreateInstanceSetting(instanceSettingObject);
            var wordLengthRest = instanceSettingRestRepository.GetInstanceSettingValue(instanceSettingIdRest);
            var documentTextsRest = documentsRestRepository.DocumentTexts(pdfDocumentIds);
            var filteredWordsRest = wordsRepository.filteredWords(documentTextsRest, wordLengthRest, false);

            //Net
            net();
        }
        public static void net()
        {
            var connection = new ServicesMgr();
            InstanceSettingNetRepository instanceSettingNetRepository = new InstanceSettingNetRepository(connection);
            DocumentsNetRepository documentsNetRepository = new DocumentsNetRepository(connection);
            WordsRepository wordsRepository = new WordsRepository();
            InstanceSettingObject instanceSettingObjectToNet = new InstanceSettingObject()
            {
                Name = "Example 18 Net",
                Value = 10,
                InitialValue = 10,
                Description = "Onboarding Description",
                Section = "Onboarding Section"
            };
            var documentTextsNet = documentsNetRepository.Documents(_savedSearchId);
            var instanceSettingIdNet = instanceSettingNetRepository.CreateInstanceSetting(instanceSettingObjectToNet);
            var wordLengthNet = instanceSettingNetRepository.GetInstanceSettingValue(instanceSettingIdNet);
            var filteredWordsNet = wordsRepository.filteredWords(documentTextsNet, wordLengthNet, true);
        }
    }
}
