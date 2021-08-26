using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesNet.Inferfaces
{
    public interface IWordFoundNetRepository
    {
        void CreateWordFoundObject(IObjectManager helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
