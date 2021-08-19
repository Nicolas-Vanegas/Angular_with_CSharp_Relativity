namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IInstanceSettingNetService
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, ServicesMgr helper);
        int GetInstanceSettingValue(int instanceSettingId, ServicesMgr helper);
    }
}
