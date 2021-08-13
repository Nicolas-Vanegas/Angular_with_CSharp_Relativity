using ConsoleApp1.Domain.DomainNet.Interfaces;

namespace ConsoleApp1.Domain.DomainNet
{
    public class StartNetService
    {
        private readonly IInstanceSettingNetService _instanceSettingNetService;
        private readonly IDocumentNetService _documentNetService;
        static int _savedSearchId = 1047249;

        public StartNetService(IInstanceSettingNetService instanceSettingNetService, IDocumentNetService documentNetService)
        {
            _instanceSettingNetService = instanceSettingNetService;
            _documentNetService = documentNetService;
        }
        void startApplication()
        {
            //Create InstanceSetting Return the ArtifactID
            var connection = new ServicesMgr();
            InstanceSettingObject instanceSettingObjectToNet = new InstanceSettingObject()
            {
                Name = "Example 18 Net",
                Value = 10,
                InitialValue = 10,
                Description = "Onboarding Description",
                Section = "Onboarding Section"
            };
            var documentTextsNet = _documentNetService.GetDocumentsBySavedSearchId(_savedSearchId, connection);
            var instanceSettingIdNet = _instanceSettingNetService.CreateInstanceSetting(instanceSettingObjectToNet, connection);
            var wordLengthNet = _instanceSettingNetService.GetInstanceSettingValue(instanceSettingIdNet, connection);
            //var filteredWordsNet = _wordsRepository.filteredWords(documentTextsNet, wordLengthNet, true);
        }
    }
}
