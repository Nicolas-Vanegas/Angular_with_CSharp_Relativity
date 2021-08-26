using ConsoleApp1.Common.Constants;
using ConsoleApp1.Object;
using ConsoleApp1.RepositoryNet.Inferfaces;
using Relativity.Services.Objects;
using Relativity.Services.Objects.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.RepositoryNet
{
    public class DocumentsNetRepository : IDocumentsNetRepository
    {
        public List<DocumentWithExtractedTextObject> Documents(int savedSearchId, IObjectManager helper)

        {
            try
            {
                var extractedTextAndDocumentArtifactId = new List<DocumentWithExtractedTextObject>();
                var documentTextExtractedList = new List<string>();

                var queryRequest = new QueryRequest
                {
                    Fields = new List<FieldRef>() {
                        new FieldRef { Name = "Extracted Text" },
                        new FieldRef { Name = "Control Number" }
                    },
                    ObjectType = new ObjectTypeRef
                    {
                        ArtifactTypeID = 10
                    },
                    Condition = $"'Artifact ID' IN SAVEDSEARCH {savedSearchId}"
                };
                using (var objectManager = helper)
                {
                    var result = objectManager.QuerySlimAsync(Constants.WORKSPACE_ID, queryRequest, 0, 0).ConfigureAwait(false).GetAwaiter().GetResult();
                    var documents = result.Objects;
                    foreach (var document in documents)
                    {
                        var documentWithExtractedTextObject = new DocumentWithExtractedTextObject()
                        {
                            ArtifactID = document.ArtifactID,
                            ExtractedText = document.Values.FirstOrDefault().ToString(),
                            ControlNumber = document.Values[1].ToString()
                        };
                        extractedTextAndDocumentArtifactId.Add(documentWithExtractedTextObject);
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
