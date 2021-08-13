using System.Collections.Generic;

namespace ConsoleApp1.RepositoryNet.Inferfaces
{
    public interface IDocumentsNetRepository
    {
        List<string> Documents(int savedSearchId, ServicesMgr helper);
    }
}
