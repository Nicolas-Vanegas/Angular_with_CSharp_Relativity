using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using ConsoleApp1.Object;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet
{
    public class WordFoundNetService : IWordFoundNetService
    {
        private readonly IWordFoundNetDataProvider _wordFoundNetDataProvider;
        public WordFoundNetService(IWordFoundNetDataProvider wordFoundNetDataProvider)
        {
            _wordFoundNetDataProvider = wordFoundNetDataProvider;
        }
        public void CreateWordFoundObject(ServicesMgr helper, List<WordWithDocumentArtifactIdObject> filteredWords, int wordLengthNet)
        {
            var created = true;
            if (!created)
            {
                _wordFoundNetDataProvider.CreateWordFoundObject(helper, filteredWords, wordLengthNet);
            }
        }
    }
}
