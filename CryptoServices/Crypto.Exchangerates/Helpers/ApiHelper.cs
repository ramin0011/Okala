using AutoMapper;
using Crypto.Base.Models;
using Crypto.Shared.Models.ExchangeRate;
using RestSharp;

namespace Crypto.Exchangerates.Helpers;

public class ApiHelper : IExchageRateApiHelper
{
    public async Task<(ApiResponse apiResult, CryptoQuote quotes)> GetQuotes(IRestClient clien,IMapper mapper)
    {
        var restRequest = new RestRequest();
        var response = await clien.ExecuteAsync(restRequest,CancellationToken.None);
        var apiResult = ApiResponse.FromJson(response.Content);
        var quotes = mapper.Map<ApiResponse, CryptoQuote>(apiResult);
        return (apiResult, quotes);
    }

    public IRestClient GetRestClient(string apikey, RequestModel model)
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