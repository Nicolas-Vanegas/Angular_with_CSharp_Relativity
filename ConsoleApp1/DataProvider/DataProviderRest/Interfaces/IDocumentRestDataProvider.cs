using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderRest.Interfaces
{
    public interface IDocumentRestDataProvider
    {
        List<int> Documents(int savedSearchId);
        List<string> DocumentTexts(List<int> documentIds);
    }
}
