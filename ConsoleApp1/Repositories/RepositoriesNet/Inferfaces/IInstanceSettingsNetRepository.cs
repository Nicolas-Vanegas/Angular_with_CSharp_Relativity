using Relativity.Services.Interfaces.InstanceSetting;

namespace ConsoleApp1
{
    public interface IInstanceSettingsNetRepository
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, IInstanceSettingManager helper);
        int GetInstanceSettingValue(int instanceSettingId, IInstanceSettingManager helper);
    }
}
