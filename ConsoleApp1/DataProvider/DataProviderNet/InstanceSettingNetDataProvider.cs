using ConsoleApp1.DataProvider.Interfaces;

namespace ConsoleApp1.DataProvider
{
    public class InstanceSettingNetDataProvider : IInstanceSettingNetDataProvider
    {
        private readonly IInstanceSettingsNetRepository _instanceSettingNetRepository;

        public InstanceSettingNetDataProvider(IInstanceSettingsNetRepository instanceSettingNetRepository)
        {
            _instanceSettingNetRepository = instanceSettingNetRepository;
        }
        public int CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper)
        {
            return _instanceSettingNetRepository.CreateInstanceSetting(instanceSettingObject, helper);
        }

        public int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper)
        {
            return _instanceSettingNetRepository.GetInstanceSettingValue(instanceSettingId, helper);
        }
    }
}
