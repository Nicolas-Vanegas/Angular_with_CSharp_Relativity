namespace ConsoleApp1.DataProvider.DataProviderRest.Interfaces
{
    public interface IInstanceSettingRestDataProvider
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject);
        int GetInstanceSettingValue(int instanceSettingId);
    }
}
