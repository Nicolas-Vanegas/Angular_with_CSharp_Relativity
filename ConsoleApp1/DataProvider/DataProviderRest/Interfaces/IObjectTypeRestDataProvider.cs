using ConsoleApp1.RepositoryRest;

namespace ConsoleApp1.DataProvider.DataProviderRest.Interfaces
{
    public interface IObjectTypeRestDataProvider
    {
        int CreateObjectType(HttpClientConnection helper);
    }
}
