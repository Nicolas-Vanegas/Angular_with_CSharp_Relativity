using ConsoleApp1.RepositoryRest;
using ConsoleApp1.RepositoryRest.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1
{
    public class InstanceSettingRestRepository : IInstanceSettingRestRepository
    {
        private readonly HttpClientRepository _httpClientRepository;
        public InstanceSettingRestRepository(HttpClientRepository httpClientRepository)
        {
            _httpClientRepository = httpClientRepository;
        }
        public int CreateInstanceSetting(InstanceSettingObject instanceSettingObject)
        {
            string url = "/Relativity.REST/api/Relativity.InstanceSettings/workspace/-1/instancesettings/";
            string payload = $@"{{
                ""instanceSetting"": {{
                    ""Name"": ""{instanceSettingObject.Name}"",
                    ""Section"": ""{instanceSettingObject.Section}"",
                    ""Machine"": """",
                    ""ValueType"": 2,
                    ""Value"": {instanceSettingObject.Value},
                    ""InitialValue"": {instanceSettingObject.InitialValue},
                    ""Encrypted"": false,
                    ""Description"": ""Onboarding description"",
                    ""Keywords"": ""Sample keywords"",
                    ""Notes"": ""Sample notes""
                }}
            }}";

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpClient = _httpClientRepository.GetHttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url, content).ConfigureAwait(false).GetAwaiter().GetResult();
            string result = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to create InstanceSetting: {result}");
            }
            int artifactID = int.Parse(result);
            return artifactID;
        }

        public int GetInstanceSettingValue(int instanceSettingId)
        {
            string url = $"Relativity.REST/api/Relativity.InstanceSettings/workspace/-1/instancesettings/{instanceSettingId}";
            var httpClient = _httpClientRepository.GetHttpClient();
            HttpResponseMessage response = httpClient.GetAsync(url).ConfigureAwait(false).GetAwaiter().GetResult();
            var instanceSettingValue = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            InstanceSettingObject instanceSettingObject = JsonConvert.DeserializeObject<InstanceSettingObject>(instanceSettingValue);
            return instanceSettingObject.Value;
        }
    }
}
