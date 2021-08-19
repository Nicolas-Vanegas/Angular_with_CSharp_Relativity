using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1.Domain.DomainRest.Interfaces
{
    public interface IObjectTypeRestService
    {
        int CreateObjectType(HttpClientConnection helper);
    }
}
