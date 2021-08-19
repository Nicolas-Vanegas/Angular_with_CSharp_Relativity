using ConsoleApp1.DataProvider.Interfaces;
using ConsoleApp1.Domain.DomainNet.Interfaces;

namespace ConsoleApp1.Domain.DomainNet
{
    public class InstanceSettingNetService : IInstanceSettingNetService
    {
        private readonly IInstanceSettingNetDataProvider _instanceSettingNetDataprovider;
        public InstanceSettingNetService(IInstanceSettingNetDataProvider instanceSettingsNetDataprovider)
        {
            _instanceSettingNetDataprovider = instanceSettingsNetDataprovider;
        }
        public void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr _helper)
        {
            var created = true;
            if (!created)
            {
                _instanceSettingNetDataprovider.CreateInstanceSetting(instanceSettingObject, _helper);
            }
        }

        public int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper)
        {
            return _instanceSettingNetDataprovider.GetInstanceSettingValue(instanceSettingId, helper);
        }
    }
}
