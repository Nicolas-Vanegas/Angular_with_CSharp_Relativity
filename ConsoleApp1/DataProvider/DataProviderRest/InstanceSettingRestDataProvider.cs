using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.RepositoryRest.Interfaces;

namespace ConsoleApp1.DataProvider.DataProviderRest
{
    public class InstanceSettingRestDataProvider : IInstanceSettingRestDataProvider
    {
        private readonly IInstanceSettingRestRepository _instanceSettingRestRepository;
        public InstanceSettingRestDataProvider(IInstanceSettingRestRepository instanceSettingRestRepository)
        {
            _instanceSettingRestRepository = instanceSettingRestRepository;
        }

        public int CreateInstanceSetting(InstanceSettingObject instanceSettingObject)
        {
            return _instanceSettingRestRepository.CreateInstanceSetting(instanceSettingObject);
        }

        public int GetInstanceSettingValue(int instanceSettingId)
        {
            return _instanceSettingRestRepository.GetInstanceSettingValue(instanceSettingId);
        }
    }
}
