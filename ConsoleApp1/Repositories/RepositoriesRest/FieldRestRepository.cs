using ConsoleApp1.Common.Constants;
using ConsoleApp1.Repositories.RepositoriesRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1.Repositories.RepositoriesRest
{
    public class FieldRestRepository : IFieldRestRepository
    {
        public void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames)
        {
            string url = $"/Relativity.REST/api/Relativity.Fields/workspace/{Constants.WORKSPACE_ID}/multipleobjectfields/";
            foreach (var fieldName in fieldNames)
            {
                string payload = $@"{{
                    ""fieldRequest"": {{
	                    ""Name"": ""{fieldName}"",

                        ""ObjectType"": {{
                                ""ArtifactID"": {Constants.WORD_FOUND_ARTIFACT_ID},
	                            ""ArtifactTypeID"": {Constants.WORD_FOUND_ARTIFACT_TYPE_ID}

                        }},
	                    ""AssociativeObjectType"": {{
                                ""ArtifactID"": {Constants.DOCUMENT_ARTIFACT_ID},
                        }},
	                    ""Source"": """",
	                    ""IsRequired"": true,
	                    ""AvailableInFieldTree"": false,
	                    ""OverlayBehavior"": ""ReplaceValues"",
	                    ""IsLinked"": false,
	                    ""FilterType"": ""None"",
	                    ""Width"": null, 
	                    ""AllowGroupBy"": false,
	                    ""AllowPivot"": false,
                        ""Keywords"": """",
                        ""Notes"": """"
                    }}
                }}";

                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var httpClient = helper.GetHttpClient();

                HttpResponseMessage response = httpClient.PostAsync(url, content).ConfigureAwait(false).GetAwaiter().GetResult();
                var fieldJson = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Failed to read documents: {response}");
                }
            }
        }
    }
}
