using Relativity.Services.ServiceProxy;
using System;


public class ServicesMgr
{
    public ServiceFactory getNewServiceFactory(string yourURL, string username, string password)
    {
        String restServerAddress = $"http://{yourURL}/relativity.rest/api/";

        Uri keplerUri = new Uri(restServerAddress);

        ServiceFactorySettings settings = new ServiceFactorySettings(
           keplerUri, new UsernamePasswordCredentials($"{username}", $"{password}"));

        ServiceFactory _serviceFactory = new ServiceFactory(settings);

        return _serviceFactory;
    }
}