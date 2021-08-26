using Relativity.Services.Interfaces.InstanceSetting;

namespace ConsoleApp1.Domain.DomainNet.Interfaces
{
    public interface IInstanceSettingNetService
    {
        void CreateInstanceSetting(InstanceSettingObject instanceSettingObject, IInstanceSettingManager helper);
        int GetInstanceSettingValue(int instanceSettingId, IInstanceSettingManager helper);
    }
}
