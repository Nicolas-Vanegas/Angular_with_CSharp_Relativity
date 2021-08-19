using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IWordFoundNetService
    {
        void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
