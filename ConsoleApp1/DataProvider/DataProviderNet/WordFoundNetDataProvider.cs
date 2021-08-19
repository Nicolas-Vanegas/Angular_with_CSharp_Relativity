using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Object;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderNet
{
    public class WordFoundNetDataProvider : IWordFoundNetDataProvider
    {
        private readonly IWordFoundNetRepository _wordFoundNetRepository;
        public WordFoundNetDataProvider(IWordFoundNetRepository wordFoundNetRepository)
        {
            _wordFoundNetRepository = wordFoundNetRepository;
        }
        public void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet)
        {
            _wordFoundNetRepository.CreateWordFoundObject(helper, filteredWords, wordLengthNet);
        }
    }
}
