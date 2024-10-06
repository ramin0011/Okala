using Crypto.Base.Enums;
using Crypto.Base.Models;
using Crypto.Base.Services;

namespace Crypto.Exchangerates;

public class Service:ICryptoQuoteService
{
    public ProviderType Type { get; set; } = ProviderType.ExchangeRate;

    public Task<CryptoQuote> GetQuotes(RequestModel request)
    {
        return Task.FromResult(new CryptoQuote());
    }
}