using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IDocumentNetService
    {
        List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, IObjectManager helper);
    }
}
