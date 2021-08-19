using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.DataProvider.DataProviderRest.Interfaces
{
    public interface IFieldRestDataProvider
    {
        void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames);
    }
}
