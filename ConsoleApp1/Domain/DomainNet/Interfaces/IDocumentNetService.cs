using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IDocumentNetService
    {
        List<string> GetDocumentsBySavedSearchId(int savedSearchId, ServicesMgr helper);
    }
}
