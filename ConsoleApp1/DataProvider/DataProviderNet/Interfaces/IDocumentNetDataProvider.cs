using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IDocumentNetDataProvider
    {
        List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, IObjectManager helper);
    }
}
