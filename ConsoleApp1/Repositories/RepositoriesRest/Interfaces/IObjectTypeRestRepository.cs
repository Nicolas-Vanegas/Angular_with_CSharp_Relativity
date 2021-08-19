using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1.Repositories.RepositoriesRest.Interfaces
{
    public interface IObjectTypeRestRepository
    {
        int CreateObjectType(HttpClientConnection helper);
    }
}
