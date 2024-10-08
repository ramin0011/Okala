using Crypto.Base.Enums;
using Crypto.Base.Services;
using Crypto.Exchangerates.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.Api.Discovery;

public static class ServiceManager
{
    public static void RegisterCryptoServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICryptoQuoteService, CoinMarket.Service>();
        serviceCollection.AddTransient<ICryptoQuoteService, Exchangerates.Service>();
        serviceCollection.AddTransient<IExchageRateApiHelper, Exchangerates.Helpers.ApiHelper>();
    }

    public static ICryptoQuoteService  FindCryptoService(this IEnumerable<ICryptoQuoteService> services, ProviderType type)
    {
        return services.FirstOrDefault(a => a.Type == type);
    }
}