using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Utils;

namespace ConsoleApp1.Domain.DomainNet
{
    public class StartNetService : IStartNetService
    {
        private readonly IInstanceSettingNetService _instanceSettingNetService;
        private readonly IDocumentNetService _documentNetService;
        private readonly IWords _words;
        static int _savedSearchId = 1047249;

        public StartNetService(IInstanceSettingNetService instanceSettingNetService, IDocumentNetService documentNetService, IWords words)
        {
            _instanceSettingNetService = instanceSettingNetService;
            _documentNetService = documentNetService;
            _words = words;
        }
        void IStartNetService.startApplication()
        {
            //Create InstanceSetting Return the ArtifactID
            var connection = new ServicesMgr();
            InstanceSettingObject instanceSettingObjectToNet = new InstanceSettingObject()
            {
                Name = "Example 19 Net",
                Value = 10,
                InitialValue = 10,
                Description = "Onboarding Description",
                Section = "Onboarding Section"
            };
            var instanceSettingIdNet = _instanceSettingNetService.CreateInstanceSetting(instanceSettingObjectToNet, connection);
            var documentTextsNet = _documentNetService.GetDocumentsBySavedSearchId(_savedSearchId, connection);
            var wordLengthNet = _instanceSettingNetService.GetInstanceSettingValue(instanceSettingIdNet, connection);
            var filteredWordsNet = _words.filteredWords(documentTextsNet, wordLengthNet, true);
        }
    }
}
