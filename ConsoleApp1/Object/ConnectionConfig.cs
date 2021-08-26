using System;
using System.IO;

namespace ConsoleApp1.Object
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ConnectionConfig
    {
        public static Lazy<ConnectionConfig> Instance = new Lazy<ConnectionConfig>(() => Setup());
        public static ConnectionConfig Setup()
        {
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<ConnectionConfig>(File.ReadAllText("Tests/config.json"));
            return config;
        }
        public string RestUrl { get; set; }
        public Credentials Creds { get; set; }
    }
}
