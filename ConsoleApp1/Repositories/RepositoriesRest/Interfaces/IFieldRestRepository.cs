using ConsoleApp1.RepositoryRest;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories.RepositoriesRest.Interfaces
{
    public interface IFieldRestRepository
    {
        void CreateMultiObjectField(HttpClientConnection helper, List<string> fieldNames);
    }
}
