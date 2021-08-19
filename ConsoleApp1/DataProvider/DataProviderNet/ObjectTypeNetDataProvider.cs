using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;

namespace ConsoleApp1.DataProvider.DataProviderNet
{
    public class ObjectTypeNetDataProvider : IObjectTypeNetDataProvider
    {
        private readonly IObjectTypeNetRepository _objectTypeRepository;
        public ObjectTypeNetDataProvider(IObjectTypeNetRepository objectTypeRepository)
        {
            _objectTypeRepository = objectTypeRepository;
        }

        public void CreateObjectType(ServicesMgr helper)
        {
            _objectTypeRepository.CreateObjectType(helper);
        }
    }
}