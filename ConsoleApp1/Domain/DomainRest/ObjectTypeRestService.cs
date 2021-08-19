using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1.Domain.DomainRest
{
    public class ObjectTypeRestService : IObjectTypeRestService
    {
        private readonly IObjectTypeRestDataProvider _objectTypeRestDataProvider;
        public ObjectTypeRestService(IObjectTypeRestDataProvider objectTypeRestDataProvider)
        {
            _objectTypeRestDataProvider = objectTypeRestDataProvider;
        }

        public int CreateObjectType(HttpClientConnection helper)
        {
            return _objectTypeRestDataProvider.CreateObjectType(helper);
        }
    }
}
