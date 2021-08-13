using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IDocumentNetDataProvider
    {
        List<string> GetDocumentsBySavedSearchId(int savedSearchId, ServicesMgr helper);
    }
}
