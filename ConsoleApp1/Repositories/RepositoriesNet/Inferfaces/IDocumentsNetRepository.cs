using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.RepositoryNet.Inferfaces
{
    public interface IDocumentsNetRepository
    {
        List<DocumentWithExtractedTextObject> Documents(int savedSearchId, ServicesMgr helper);
    }
}
