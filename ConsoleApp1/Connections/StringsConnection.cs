using ConsoleApp1.Object;

namespace ConsoleApp1.Connections
{
    public class StringsConnection
    {
        public ConnectionConfig GetStringsConnection()
        {
            return new ConnectionConfig()
            {
                RestUrl = $"http://192.168.20.31/relativity.rest/api/",
                Creds = new Credentials()
                {
                    Username = "Relativity.admin@relativity.com",
                    Password = "Test1234!"
                }
            };
        }

    }
}
