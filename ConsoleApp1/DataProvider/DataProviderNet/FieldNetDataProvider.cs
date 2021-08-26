using ConsoleApp1.DataProvider.DataProviderNet.Interfaces;
using ConsoleApp1.Repositories.RepositoriesNet.Inferfaces;
using Relativity.Services.Interfaces.Field;
using Relativity.Services.Interfaces.ObjectType;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderNet
{
    public class FieldNetDataProvider : IFieldNetDataProvider
    {
        private readonly IFieldNetRepository _fieldRepository;
        public FieldNetDataProvider(IFieldNetRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }
        public void CreateLongTextField(IFieldManager helper, List<string> fieldNames)
        {
            _fieldRepository.CreateLongTextField(helper, fieldNames);
        }
    }
}
