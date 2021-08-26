using ConsoleApp1.Domain.DomainNet.Interfaces;
using Relativity.Services.Objects;
using System.Web.Http;

namespace RelCustomPage.Controllers
{
    public class DocumentController : BaseController
    {
        private readonly IDocumentNetService _documentNetService;

        public DocumentController(IDocumentNetService documentNetService)
        {
            _documentNetService = documentNetService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/{workspaceId:int}/documents")]
        public IHttpActionResult GetDocuments(int workspaceId)
        {
            var no = HelperFactory.GetHelper().GetServicesManager().CreateProxy<IObjectManager>(Relativity.API.ExecutionIdentity.CurrentUser);
            int _savedSearchId = 1047249;
            var documents = _documentNetService.GetDocumentsBySavedSearchId(_savedSearchId, no);
            return Ok(documents);
        }
    }
}