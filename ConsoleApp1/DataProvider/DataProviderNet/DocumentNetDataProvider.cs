using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Object;
using ConsoleApp1.RepositoryNet.Inferfaces;
using Relativity.Services.Objects;
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
        public List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, IObjectManager helper)
        {
            return _documentNetRepository.Documents(savedSearchId, helper);
        }
    }
}
