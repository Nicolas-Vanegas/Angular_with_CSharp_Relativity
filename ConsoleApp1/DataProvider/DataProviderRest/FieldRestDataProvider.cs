using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Repositories.RepositoriesRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderRest
{
    public class FieldRestDataProvider : IFieldRestDataProvider
    {
        private readonly IFieldRestRepository _fieldRestRepository;
        public FieldRestDataProvider(IFieldRestRepository fieldRestRepository)
        {
            _fieldRestRepository = fieldRestRepository;
        }
        public void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames)
        {
            _fieldRestRepository.CreateMultiObjectField(helper, fieldNames);
        }
    }
}
