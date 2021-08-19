using System.Net;

namespace ConsoleApp1.Connections
{
    public class WebClientConnection
    {
        public string GetJsonDictionary(string word)
        {
            var result = (string)null;
            try
            {
                using (var client = new WebClient())
                {
                    string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
                    result = client.DownloadString(url);
                }
                return result;
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return result;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
