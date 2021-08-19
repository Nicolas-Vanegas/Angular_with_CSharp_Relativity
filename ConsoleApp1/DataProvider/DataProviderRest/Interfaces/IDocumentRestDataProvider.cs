using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderRest.Interfaces
{
    public interface IDocumentRestDataProvider
    {
        List<int> Documents(int savedSearchId);
        List<DocumentWithExtractedTextObject> DocumentTexts(List<int> documentIds);
    }
}
