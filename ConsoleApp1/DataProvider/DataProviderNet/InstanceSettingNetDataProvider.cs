using ConsoleApp1.DataProvider.Interfaces;
using Relativity.Services.Interfaces.InstanceSetting;

namespace ConsoleApp1.DataProvider
{
    public class InstanceSettingNetDataProvider : IInstanceSettingNetDataProvider
    {
        private readonly IInstanceSettingsNetRepository _instanceSettingNetRepository;

        public InstanceSettingNetDataProvider(IInstanceSettingsNetRepository instanceSettingNetRepository)
        {
            _instanceSettingNetRepository = instanceSettingNetRepository;
        }
        public void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, IInstanceSettingManager helper)
        {
            _instanceSettingNetRepository.CreateInstanceSetting(instanceSettingObject, helper);
        }

        public int GetInstanceSettingValue(int instanceSettingId, IInstanceSettingManager helper)
        {
            return _instanceSettingNetRepository.GetInstanceSettingValue(instanceSettingId, helper);
        }
    }
}
