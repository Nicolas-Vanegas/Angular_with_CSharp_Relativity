namespace ConsoleApp1
{
    public interface IInstanceSettingsNetRepository
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject);
        int GetInstanceSettingValue(int instanceSettingId);
    }
}
