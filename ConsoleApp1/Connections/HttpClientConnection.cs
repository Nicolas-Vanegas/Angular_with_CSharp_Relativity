using System;
using System.Net.Http;
using System.Text;

namespace ConsoleApp1.RepositoryRest
{
    public class HttpClientConnection
    {
        public HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://192.168.20.31/");
            httpClient.DefaultRequestHeaders.Add("X-CSRF-Header", "-");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("relativity.admin@relativity.com:Test1234!")));

            return httpClient;
        }
    }
}
