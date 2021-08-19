using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IDocumentNetDataProvider
    {
        List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, ServicesMgr helper);
    }
}
