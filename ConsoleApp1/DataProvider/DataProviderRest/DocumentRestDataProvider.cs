using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderRest
{
    public class DocumentRestDataProvider : IDocumentRestDataProvider
    {
        private readonly IDocumentsRestRepository _documentsRestRepository;
        public DocumentRestDataProvider(IDocumentsRestRepository documentRestRepository)
        {
            _documentsRestRepository = documentRestRepository;
        }
        public List<int> Documents(int savedSearchId)
        {
            return _documentsRestRepository.Documents(savedSearchId);
        }

        public List<string> DocumentTexts(List<int> documentIds)
        {
            return _documentsRestRepository.DocumentTexts(documentIds);
        }
    }
}
