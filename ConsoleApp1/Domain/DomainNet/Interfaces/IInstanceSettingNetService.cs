namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IInstanceSettingNetService
    {
        int CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
