using ConsoleApp1.Object;
using Relativity.Services.ServiceProxy;
using System;


public sealed class ServicesMgr
{
    private readonly ConnectionConfig _connectionConfig;
    private readonly ServiceFactory _serviceFactory;

    private static ServicesMgr instance = null;
    private ServicesMgr(ConnectionConfig config)
    {
        _connectionConfig = config;
        var factorySettings = new ServiceFactorySettings(new Uri(config.RestUrl), new UsernamePasswordCredentials(config.Creds.Username, config.Creds.Password));
        _serviceFactory = new ServiceFactory(factorySettings);
    }
    public static ServicesMgr GetInstance(ConnectionConfig config)
    {
        if (instance == null)
        {
            instance = new ServicesMgr(config);
        }
        return instance;
    }

    public T CreateProxy<T>() where T : IDisposable
    {
        return _serviceFactory.CreateProxy<T>();
    }
}