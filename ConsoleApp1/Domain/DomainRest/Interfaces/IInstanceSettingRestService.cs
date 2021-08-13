namespace ConsoleApp1.Domain.DomainRest.Interfaces
{
    public interface IInstanceSettingRestService
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject);
        int GetInstanceSettingValue(int instanceSettingId);
    }
}
