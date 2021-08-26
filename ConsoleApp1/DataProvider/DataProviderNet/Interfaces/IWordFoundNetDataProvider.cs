using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderNet.Interfaces
{
    public interface IWordFoundNetDataProvider
    {
        void CreateWordFoundObject(IObjectManager helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
