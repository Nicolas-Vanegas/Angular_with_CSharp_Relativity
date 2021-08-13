using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;

namespace ConsoleApp1.Domain.DomainRest
{
    public class InstanceSettingRestService : IInstanceSettingRestService
    {
        private IInstanceSettingRestDataProvider _instanceSettingRestDataProvider;
        public InstanceSettingRestService(IInstanceSettingRestDataProvider instanceSettingRestDataProvider)
        {
            _instanceSettingRestDataProvider = instanceSettingRestDataProvider;
        }
        public int CreateInstanceSetting(InstanceSettingObject instanceSettingObject)
        {
            return _instanceSettingRestDataProvider.CreateInstanceSetting(instanceSettingObject);
        }

        public int GetInstanceSettingValue(int instanceSettingId)
        {
            return _instanceSettingRestDataProvider.GetInstanceSettingValue(instanceSettingId);
        }
    }
}
