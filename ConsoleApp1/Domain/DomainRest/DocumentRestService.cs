using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainRest
{
    public class DocumentRestService : IDocumentRestService
    {
        private readonly IDocumentRestDataProvider _documentNetDataProvider;
        public DocumentRestService(IDocumentRestDataProvider documentNetDataProvider)
        {
            _documentNetDataProvider = documentNetDataProvider;
        }
        public List<int> Documents(int savedSearchId)
        {
            return _documentNetDataProvider.Documents(savedSearchId);
        }

        public List<DocumentWithExtractedTextObject> DocumentTexts(List<int> documentIds)
        {
            return _documentNetDataProvider.DocumentTexts(documentIds);
        }
    }
}
