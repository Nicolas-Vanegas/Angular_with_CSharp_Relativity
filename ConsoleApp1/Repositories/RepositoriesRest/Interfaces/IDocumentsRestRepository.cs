using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.RepositoryRest
{
    public interface IDocumentsRestRepository
    {
        List<int> Documents(int savedSearchId);
        List<DocumentWithExtractedTextObject> DocumentTexts(List<int> documentIds);
    }
}
