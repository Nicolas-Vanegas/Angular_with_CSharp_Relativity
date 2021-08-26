using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Domain.DomainNet.Interfaces;
using Relativity.Services.Interfaces.Field;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainNet
{
    public class FieldNetService : IFieldNetService
    {
        private readonly IFieldNetDataProvider _fieldNetDataProvider;
        public FieldNetService(IFieldNetDataProvider fieldNetDataProvider)
        {
            _fieldNetDataProvider = fieldNetDataProvider;
        }
        public void CreateLongTextField(IFieldManager helper, List<string> fieldNames)
        {
            var created = true;
            if (!created)
            {
                _fieldNetDataProvider.CreateLongTextField(helper, fieldNames);
            }
        }
    }
}
