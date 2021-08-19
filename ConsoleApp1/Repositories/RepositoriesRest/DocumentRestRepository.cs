using ConsoleApp1.Common.Constants;
using ConsoleApp1.Object;
using Newtonsoft.Json;
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
        private readonly HttpClientConnection _httpClientRepository;

        public DocumentsRestRepository(HttpClientConnection httpClientRepository)
        {
            _httpClientRepository = httpClientRepository;
        }
        public List<int> Documents(int savedSearchId)
        {
            string url = $"Relativity.Rest/API/Relativity.Objects/workspace/{Constants.WORKSPACE_ID}/object/queryslim";
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
        public List<DocumentWithExtractedTextObject> DocumentTexts(List<int> documentIds)
        {
            string url = $"Relativity.Rest/API/Relativity.Objects/workspace/{Constants.WORKSPACE_ID}/object/queryslim";
            var extractedTextAndDocumentArtifactId = new List<DocumentWithExtractedTextObject>();
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
                var document = JsonConvert.DeserializeObject<QueryResultSlim>(documents);

                foreach (var item in document.Objects)
                {
                    extractedTextAndDocumentArtifactId.Add(new DocumentWithExtractedTextObject()
                    {
                        ExtractedText = item.Values.FirstOrDefault().ToString(),
                        ArtifactID = item.ArtifactID
                    });
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Failed to read documents: {documents}");
                }
            }
            return extractedTextAndDocumentArtifactId;
        }
    }
}
