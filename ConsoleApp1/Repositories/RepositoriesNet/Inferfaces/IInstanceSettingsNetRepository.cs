namespace ConsoleApp1
{
    public interface IInstanceSettingsNetRepository
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
