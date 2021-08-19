using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainRest.Interfaces
{
    public interface IDocumentRestService
    {
        List<int> Documents(int savedSearchId);
        List<DocumentWithExtractedTextObject> DocumentTexts(List<int> documentIds);
    }
}
