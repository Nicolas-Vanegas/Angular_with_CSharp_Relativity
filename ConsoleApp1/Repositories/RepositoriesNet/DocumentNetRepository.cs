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
        public List<string> Documents(int savedSearchId, ServicesMgr helper)
        {
            var _serviceFactory = helper.getNewServiceFactory("192.168.20.31", "relativity.admin@relativity.com", "Test1234!");
            try
            {

                var documentTextExtractedList = new List<string>();
                int workspaceId = 1017767;

                var queryRequest = new QueryRequest
                {
                    Fields = new List<FieldRef>() { new FieldRef { Name = "Heretik Extracted Text" } },
                    ObjectType = new ObjectTypeRef
                    {
                        ArtifactTypeID = 10
                    },
                    Condition = $"'Artifact ID' IN SAVEDSEARCH {savedSearchId}"
                };
                using (IObjectManager objectManager = _serviceFactory.CreateProxy<IObjectManager>())
                {
                    var result = objectManager.QuerySlimAsync(workspaceId, queryRequest, 0, 0).ConfigureAwait(false).GetAwaiter().GetResult();
                    var extractedTexts = result.Objects.Select(x => x).ToList().Select(x => x.Values).ToList().Select(x => x).ToList();
                    foreach (var extractedText in extractedTexts)
                    {
                        documentTextExtractedList.Add(extractedText[0].ToString());
                    }
                }
                return documentTextExtractedList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read documents: {ex}");
            }

        }
    }
}
