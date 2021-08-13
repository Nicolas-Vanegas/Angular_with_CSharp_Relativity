namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IInstanceSettingNetDataProvider
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
