using AutoMapper;
using Crypto.Base.Enums;
using Crypto.Base.Models;
using Crypto.Base.Services;
using Crypto.Exchangerates.Helpers;
using Crypto.Shared.Configurations;
using Microsoft.Extensions.Options;

namespace Crypto.Exchangerates;


public class Service(IMapper mapper, IOptions<ProvidersKeys> options,IExchageRateApiHelper apiHelper) : ICryptoQuoteService
{
    public  ProviderType Type { get; set; } = ProviderType.ExchangeRate;
    private readonly string apiKey = options.Value.ExchangeRateApiKey;

    public async Task<ResponseModel<CryptoQuote>> GetQuotes(RequestModel request)
    {
        var client = apiHelper.GetRestClient(apiKey, request);
        var (apiResult, quotes) = await apiHelper.GetQuotes(client,mapper);
        var result = new ResponseModel<CryptoQuote>()
        {
            Result = quotes, IsSuccessful = apiResult.Success ?? false,
            ErrorCode = apiResult.Error?.Code,
            ErrorDescription = apiResult.Error?.Message
        };
        return await Task.FromResult(result);
    }
}