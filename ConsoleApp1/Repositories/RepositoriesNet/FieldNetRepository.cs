using ConsoleApp1.Common.Constants;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using Relativity.Services.Interfaces.Field;
using Relativity.Services.Interfaces.Shared.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesNet
{
    public class FieldNetRepository : IFieldNetRepository
    {
        public void CreateLongTextField(ServicesMgr helper, List<string> fieldNames)
        {
            try
            {
                foreach (var fieldname in fieldNames)
                {
                    var request = new Relativity.Services.Interfaces.Field.Models.LongTextFieldRequest
                    {
                        Name = fieldname,
                        ObjectType = new ObjectTypeIdentifier { Name = Constants.WORD_FOUND_NAME },
                        IsRequired = false,
                        AllowSortTally = true,
                        Source = "",
                    };
                    using (var fieldManager = helper.CreateProxy<IFieldManager>())
                    {
                        var newFieldId = fieldManager.CreateLongTextFieldAsync(Constants.WORKSPACE_ID, request).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
