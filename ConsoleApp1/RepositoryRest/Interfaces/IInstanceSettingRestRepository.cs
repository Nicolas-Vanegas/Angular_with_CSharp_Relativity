namespace ConsoleApp1.RepositoryRest.Interfaces
{
    public interface IInstanceSettingRestRepository
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject);
        int GetInstanceSettingValue(int instanceSettingId);
    }
}
