namespace ConsoleApp1.DataProvider.Interfaces
{
    public interface IInstanceSettingNetDataProvider
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
