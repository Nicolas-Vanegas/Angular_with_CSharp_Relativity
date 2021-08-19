using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderNet.Interfaces
{
    public interface IWordFoundNetDataProvider
    {
        void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
