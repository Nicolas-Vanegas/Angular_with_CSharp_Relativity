using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IDocumentNetService
    {
        List<DocumentWithExtractedTextObject> GetDocumentsBySavedSearchId(int savedSearchId, ServicesMgr helper);
    }
}
