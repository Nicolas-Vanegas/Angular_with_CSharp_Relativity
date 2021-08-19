namespace ConsoleApp1
{
    public interface IInstanceSettingsNetRepository
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
