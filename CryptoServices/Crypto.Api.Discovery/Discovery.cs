using Crypto.Base.Enums;
using Crypto.Base.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.Api.Discovery;

public static class Discovery
{
    public static void RegisterCryptoServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICryptoQuoteService, CoinMarket.Service>();
        serviceCollection.AddTransient<ICryptoQuoteService, Exchangerates.Service>();
    }

    public static ICryptoQuoteService  FindCryptoService(this IEnumerable<ICryptoQuoteService> services, ProviderType type)
    {
        return services.FirstOrDefault(a => a.Type == type);
    }
}