using System.Collections.Generic;

namespace ConsoleApp1.RepositoryRest
{
    public interface IDocumentsRestRepository
    {
        List<int> Documents(int savedSearchId);
        List<string> DocumentTexts(List<int> documentIds);
    }
}
