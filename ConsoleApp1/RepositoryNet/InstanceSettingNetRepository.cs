using Relativity.Services.Interfaces.InstanceSetting;
using System;

namespace ConsoleApp1
{
    public class InstanceSettingNetRepository : IInstanceSettingsNetRepository
    {
        private readonly ServicesMgr _helper;

        public InstanceSettingNetRepository(ServicesMgr helper)
        {
            _helper = helper;
        }
        public int CreateInstanceSetting(InstanceSettingObject instanceSettingObject)
        {
            var _serviceFactory = _helper.getNewServiceFactory("192.168.20.31", "relativity.admin@relativity.com", "Test1234!");

            try
            {

                using (IInstanceSettingManager instanceSettingManager = _serviceFactory.CreateProxy<IInstanceSettingManager>())
                {
                    Relativity.Services.Interfaces.InstanceSetting.Model.InstanceSettingRequest request = new Relativity.Services.Interfaces.InstanceSetting.Model.InstanceSettingRequest();
                    request.ValueType = Relativity.Services.Interfaces.InstanceSetting.Model.InstanceSettingValueTypeEnum.Integer32;
                    request.Value = instanceSettingObject.Value.ToString();
                    request.Name = instanceSettingObject.Name;
                    request.Description = instanceSettingObject.Description;
                    request.Section = instanceSettingObject.Section;
                    request.InitialValue = instanceSettingObject.InitialValue.ToString();
                    int artifactID = instanceSettingManager.CreateAsync(-1, request).ConfigureAwait(false).GetAwaiter().GetResult();
                    return artifactID;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public int GetInstanceSettingValue(int instanceSettingId)
        {
            var _serviceFactory = _helper.getNewServiceFactory("192.168.20.31", "relativity.admin@relativity.com", "Test1234!");

            try
            {
                using (IInstanceSettingManager instanceSettingManager = _serviceFactory.CreateProxy<IInstanceSettingManager>())
                {
                    Relativity.Services.Interfaces.InstanceSetting.Model.InstanceSettingResponse response = instanceSettingManager.ReadAsync(-1, instanceSettingId).ConfigureAwait(false).GetAwaiter().GetResult();
                    int value = Int32.Parse(response.Value);
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
