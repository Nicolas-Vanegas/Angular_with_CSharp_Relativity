using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.RepositoryNet.Inferfaces;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider
{
    public class DocumentNetDataProvider : IDocumentNetDataProvider
    {
        private readonly IDocumentsNetRepository _documentNetRepository;
        public DocumentNetDataProvider(IDocumentsNetRepository documentsNetRepository)
        {
            _documentNetRepository = documentsNetRepository;
        }
        public List<string> GetDocumentsBySavedSearchId(int savedSearchId, ServicesMgr helper)
        {
            return _documentNetRepository.Documents(savedSearchId, helper);
        }
    }
}
