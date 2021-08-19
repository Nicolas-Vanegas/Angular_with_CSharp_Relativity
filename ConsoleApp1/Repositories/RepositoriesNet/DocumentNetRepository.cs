using ConsoleApp1.Common.Constants;
using ConsoleApp1.Object;
using ConsoleApp1.RepositoryNet.Inferfaces;
using Relativity.ObjectManager.V1.Interfaces;
using Relativity.ObjectManager.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.RepositoryNet
{
    public class DocumentsNetRepository : IDocumentsNetRepository
    {
        public List<DocumentWithExtractedTextObject> Documents(int savedSearchId, ServicesMgr helper)
        {
            try
            {
                var extractedTextAndDocumentArtifactId = new List<DocumentWithExtractedTextObject>();
                var documentTextExtractedList = new List<string>();

                var queryRequest = new QueryRequest
                {
                    Fields = new List<FieldRef>() {
                        new FieldRef { Name = "Extracted Text" }
                    },
                    ObjectType = new ObjectTypeRef
                    {
                        ArtifactTypeID = 10
                    },
                    Condition = $"'Artifact ID' IN SAVEDSEARCH {savedSearchId}"
                };
                using (var objectManager = helper.CreateProxy<IObjectManager>())
                {
                    var result = objectManager.QuerySlimAsync(Constants.WORKSPACE_ID, queryRequest, 0, 0).ConfigureAwait(false).GetAwaiter().GetResult();
                    var documents = result.Objects;
                    foreach (var document in documents)
                    {
                        var sisas = new DocumentWithExtractedTextObject() { ArtifactID = document.ArtifactID, ExtractedText = document.Values.FirstOrDefault().ToString() };
                        extractedTextAndDocumentArtifactId.Add(sisas);
                    }
                }
                return extractedTextAndDocumentArtifactId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read documents: {ex}");
            }
        }
    }
}
