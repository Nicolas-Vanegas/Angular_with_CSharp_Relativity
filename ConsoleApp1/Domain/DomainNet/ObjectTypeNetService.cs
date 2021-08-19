using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Domain.DomainNet.Interfaces;

namespace ConsoleApp1.Domain.DomainNet
{
    public class ObjectTypeNetService : IObjectTypeNetService
    {
        private readonly IObjectTypeNetDataProvider _objectTypeDataProvider;
        public ObjectTypeNetService(IObjectTypeNetDataProvider objectTypeDataProvider)
        {
            _objectTypeDataProvider = objectTypeDataProvider;
        }
        public void CreateObjectType(ServicesMgr helper)
        {
            var created = true;
            if (!created)
            {
                _objectTypeDataProvider.CreateObjectType(helper);
            }
        }
    }
}
