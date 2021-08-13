using ConsoleApp1.Object;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Relativity.ObjectManager.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1.RepositoryRest
{
    public class DocumentsRestRepository : IDocumentsRestRepository
    {
        private readonly HttpClientRepository _httpClientRepository;

        public DocumentsRestRepository(HttpClientRepository httpClientRepository)
        {
            _httpClientRepository = httpClientRepository;
        }
        public List<int> Documents(int savedSearchId)
        {
            string url = "Relativity.Rest/API/Relativity.Objects/workspace/1017767/object/queryslim";
            string payload = $@" {{
                ""length"": 0,
                ""request"": {{
                    ""objectType"": {{'Name': ""Document""}},
                    ""fields"":[
                        {{""Name"": ""Name""}}
                    ],
                    ""condition"": ""'Artifact ID' IN SAVEDSEARCH {savedSearchId}"",
                    ""sorts"": []
                }},
                ""start"": 0
            }}";

            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpClient = _httpClientRepository.GetHttpClient();

            HttpResponseMessage response = httpClient.PostAsync(url, content).ConfigureAwait(false).GetAwaiter().GetResult();
            var documentsJson = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var documents = JsonConvert.DeserializeObject<QueryResult>(documentsJson);

            var documentIds = documents.Objects.Select(x => x.ArtifactID).ToList();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to read documents: {response}");
            }
            return documentIds;
        }
        public List<string> DocumentTexts(List<int> documentIds)
        {
            string url = "Relativity.Rest/API/Relativity.Objects/workspace/1017767/object/queryslim";
            var documentTextExtractedList = new List<string>();
            foreach (var documentId in documentIds)
            {
                string payload = $@" {{
                    ""length"": 0,
                    ""request"": {{
                    ""objectType"": {{""artifactTypeID"": 10}},
                    ""fields"":[
                        {{""Name"": ""Heretik Extracted Text""}}
                    ],
                    ""condition"": ""'Artifact ID' == {documentId}"",
                    ""sorts"": []
                    }},
                    ""start"": 0
                }}";

                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var httpClient = _httpClientRepository.GetHttpClient();

                HttpResponseMessage response = httpClient.PostAsync(url, content).ConfigureAwait(false).GetAwaiter().GetResult();
                var documents = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var document = JsonConvert.DeserializeObject<DocumentObject>(documents);


                JObject documentss = JObject.Parse(documents);

                foreach (var item in documentss["Objects"])
                {
                    var maincra = item["Values"];
                    var yerda = maincra.ToString();
                    documentTextExtractedList.Add(yerda);
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Failed to read documents: {documents}");
                }
            }
            return documentTextExtractedList;
        }
    }
}
