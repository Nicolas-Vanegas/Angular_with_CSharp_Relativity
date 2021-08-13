using System.Net.Http;

namespace ConsoleApp1.RepositoryRest
{
    public interface IHttpClientRepository
    {
        HttpClient GetHttpClient();
    }
}
