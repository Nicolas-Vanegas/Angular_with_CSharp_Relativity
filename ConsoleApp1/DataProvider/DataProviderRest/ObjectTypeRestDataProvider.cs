using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Repositories.RepositoriesRest.Interfaces;
using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1.DataProvider.DataProviderRest
{
    public class ObjectTypeRestDataProvider : IObjectTypeRestDataProvider
    {
        private readonly IObjectTypeRestRepository _objectTypeRestRepository;
        public ObjectTypeRestDataProvider(IObjectTypeRestRepository objectTypeRestRepository)
        {
            _objectTypeRestRepository = objectTypeRestRepository;
        }
        public int CreateObjectType(HttpClientConnection helper)
        {
            return _objectTypeRestRepository.CreateObjectType(helper);
        }
    }
}
