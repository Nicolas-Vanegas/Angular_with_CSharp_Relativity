using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.Domain.DomainRest.Interfaces
{
    public interface IFieldRestService
    {
        void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames);
    }
}
