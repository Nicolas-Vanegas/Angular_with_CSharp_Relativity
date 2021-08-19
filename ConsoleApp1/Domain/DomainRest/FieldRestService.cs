using ConsoleApp1.DataProvider.DataProviderRest.Interfaces;
using ConsoleApp1.Domain.DomainRest.Interfaces;
using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainRest
{
    public class FieldRestService : IFieldRestService
    {
        private readonly IFieldRestDataProvider _fieldRestDataProvider;
        public FieldRestService(IFieldRestDataProvider fieldRestDataProvider)
        {
            _fieldRestDataProvider = fieldRestDataProvider;
        }
        public void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames)
        {
            var created = true;
            if (!created)
            {
                _fieldRestDataProvider.CreateMultiObjectField(helper, fieldNames);
            }
        }
    }
}
