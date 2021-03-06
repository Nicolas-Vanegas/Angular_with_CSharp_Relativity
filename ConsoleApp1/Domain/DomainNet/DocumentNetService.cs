using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public class DocumentService : IDocumentNetService
    {
        private readonly IDocumentNetDataProvider _documentNetDataProvider;
        public DocumentService(IDocumentNetDataProvider documentNetDataProvider)
        {
            _documentNetDataProvider = documentNetDataProvider;
        }
        public List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, IObjectManager helper)
        {
            return _documentNetDataProvider.GetDocumentsBySavedSearchId(savedSearchId, helper);
        }
    }
}
