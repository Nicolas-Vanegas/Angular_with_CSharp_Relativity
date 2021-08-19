using ConsoleApp1.Common.Constants;
using ConsoleApp1.Repositories.RepositoriesRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1.Repositories.RepositoriesRest
{
    public class ObjectTypeRestRepository : IObjectTypeRestRepository
    {
        public int CreateObjectType(HttpClientConnection helper)
        {
            string url = $"/Relativity.REST/api/Relativity.objectTypes/workspace/{Constants.WORKSPACE_ID}/objectTypes/";
            string payload = $@"{{
               ""ObjectTypeRequest"" : {{
                   ""ParentObjectType"": {{
                        ""Secured"": false,
                        ""Value"": {{
                            ""ArtifactTypeID"": {Constants.WORKSPACE_ARTIFACT_TYPE_ID},
                            ""ArtifactID"": {Constants.WORKSPACE_ARTIFACT_ID}
                        }}
                    }},
                    ""Name"": ""Ignore x123"",
                    ""CopyInstancesOnCaseCreation"": false,
                    ""CopyInstancesOnParentCopy"": false,
                    ""EnableSnapshotAuditingOnDelete"": true,
                    ""PersistentListsEnabled"": false,
                    ""PivotEnabled"": true,
                    ""SamplingEnabled"": false,
                    ""Keywords"": """",
                    ""Notes"": """"
                    }}
                }}";

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpClient = helper.GetHttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url, content).ConfigureAwait(false).GetAwaiter().GetResult();
            string result = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to create ObjectType: {result}");
            }
            return int.Parse(result);
        }
    }
}
