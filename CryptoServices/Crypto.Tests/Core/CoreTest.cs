using Crypto.Api.Discovery;
using Microsoft.Extensions.DependencyInjection;

public class CoreTestFixture
{
    private ServiceProvider ServiceProvider { get;  set; }

    public CoreTestFixture()
    {
        var services = new ServiceCollection();
        services.RegisterCryptoServices();
        ServiceProvider = services.BuildServiceProvider();
    }

    protected T GetRequiredService<T>()
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}