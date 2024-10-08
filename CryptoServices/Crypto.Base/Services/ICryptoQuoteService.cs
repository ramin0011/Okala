using Crypto.Base.Enums;
using Crypto.Base.Models;

namespace Crypto.Base.Services;

public interface ICryptoQuoteService
{
    ProviderType Type { get; set; }
    Task<ResponseModel<CryptoQuote>> GetQuotes(RequestModel request);
}