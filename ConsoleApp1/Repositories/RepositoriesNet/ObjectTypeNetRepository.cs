using ConsoleApp1.Common.Constants;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using Relativity.Services.Interfaces.ObjectType;
using Relativity.Services.Interfaces.Shared.Models;
using System;

namespace ConsoleApp1.Repositories.RepositoriesNet
{
    public class ObjectTypeNetRepository : IObjectTypeNetRepository
    {
        public void CreateObjectType(IObjectTypeManager helper)
        {
            try
            {
                var request = new Relativity.Services.Interfaces.ObjectType.Models.ObjectTypeRequest
                {
                    Name = "Object to Ignore X3",
                    CopyInstancesOnCaseCreation = false,
                    CopyInstancesOnParentCopy = false,
                    EnableSnapshotAuditingOnDelete = true,
                    PersistentListsEnabled = false,
                    PivotEnabled = true,
                    SamplingEnabled = false,
                    Keywords = "",
                    Notes = "",
                    ParentObjectType = new ObjectTypeIdentifier
                    {
                        ArtifactID = Constants.WORKSPACE_ARTIFACT_ID,
                        ArtifactTypeID = Constants.WORKSPACE_ARTIFACT_TYPE_ID
                    },
                };
                using (var objectTypeManager = helper)
                {
                    var newObjectType = objectTypeManager.CreateAsync(Constants.WORKSPACE_ID, request).ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
