using ConsoleApp1.Common.Constants;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Utils;
using Relativity.Services.Interfaces.InstanceSetting;
using Relativity.Services.Objects;
using System.Web.Http;

namespace RelCustomPage.Controllers
{
    public class WordController : BaseController
    {
        private readonly IInstanceSettingNetService _instanceSettingNetService;
        private readonly IDocumentNetService _documentNetService;
        private readonly IWords _words;

        public WordController(IInstanceSettingNetService instanceSettingNetService, IDocumentNetService documentNetService, IWords words)
        {
            _instanceSettingNetService = instanceSettingNetService;
            _documentNetService = documentNetService;
            _words = words;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/{workspaceId:int}/words")]
        public IHttpActionResult GetDefinitions(int workspaceId)
        {
            var objectManager = HelperFactory.GetHelper().GetServicesManager().CreateProxy<IObjectManager>(Relativity.API.ExecutionIdentity.CurrentUser);
            int _savedSearchId = 1047249;
            var documents = _documentNetService.GetDocumentsBySavedSearchId(_savedSearchId, objectManager);
            var instanceManager = HelperFactory.GetHelper().GetServicesManager().CreateProxy<IInstanceSettingManager>(Relativity.API.ExecutionIdentity.CurrentUser);
            var instanceSettingValue = _instanceSettingNetService.GetInstanceSettingValue(Constants.INSTANCE_SETTING_ID, instanceManager);
            var filteredWords = _words.filteredWords(documents, instanceSettingValue);
            var filterDuplicatedWords = _words.duplicateWordFilter(filteredWords);
            var dictionary = _words.GetDictionary(filterDuplicatedWords, instanceSettingValue);

            return Ok(dictionary);
        }
    }
}