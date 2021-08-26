using ConsoleApp1.Object;
using Relativity.Services.Objects;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IWordFoundNetService
    {
        void CreateWordFoundObject(IObjectManager helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet);
    }
}
