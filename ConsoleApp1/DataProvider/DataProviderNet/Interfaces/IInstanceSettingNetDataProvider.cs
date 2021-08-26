using Relativity.Services.Interfaces.InstanceSetting;

namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IInstanceSettingNetDataProvider
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, IInstanceSettingManager helper);
        int GetInstanceSettingValue(int instanceSettingId, IInstanceSettingManager helper);
    }
}
