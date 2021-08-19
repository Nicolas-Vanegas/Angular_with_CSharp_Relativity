using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesNet.Inferfaces
{
    public interface IWordFoundNetRepository
    {
        void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
