using AutoMapper;
using Crypto.Base.Enums;
using Crypto.Base.Models;
using Crypto.Base.Services;
using Crypto.Exchangerates.Helpers;
using Crypto.Shared.Configurations;
using Crypto.Shared.Models.ExchangeRate;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Crypto.Exchangerates;

public class Service(IMapper mapper, IOptions<ProvidersKeys> options) : ICryptoQuoteService
{
    public  ProviderType Type { get; set; } = ProviderType.ExchangeRate;
    private readonly string apiKey = options.Value.ExchangeRateApiKey;

    public async Task<ResponseModel<CryptoQuote>> GetQuotes(RequestModel request)
    {
        var client = GetRestClient(apiKey, request);
        var restRequest = new RestRequest();
        var response = await client.ExecuteAsync(restRequest);
        var apiResult = ApiResponse.FromJson(response.Content);
        var quotes = mapper.Map<ApiResponse, CryptoQuote>(apiResult);
        var result = new ResponseModel<CryptoQuote>()
        {
            Result = quotes, IsSuccessful = apiResult.Success ?? false,
            ErrorCode = apiResult.Error?.Code,
            ErrorDescription = apiResult.Error?.Message
        };
        return await Task.FromResult(result);
    }

    private RestClient GetRestClient(string apikey, RequestModel model)
    {
        var url = ApiEndpointBuilder.GetInstance()
                .AddAccessKey(apikey)
                .AddBaseCode(model.CryptoCode)
                .AddSymbols(model.AskCodes)
                .BuildUrl()
            ;

        return new RestClient(url);
    }
}