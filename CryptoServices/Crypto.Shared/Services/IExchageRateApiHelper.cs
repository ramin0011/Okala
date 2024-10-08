using AutoMapper;
using Crypto.Base.Models;
using Crypto.Shared.Models.ExchangeRate;
using RestSharp;

namespace Crypto.Exchangerates.Helpers;

public interface IExchageRateApiHelper
{
    Task<(ApiResponse apiResult, CryptoQuote quotes)> GetQuotes(IRestClient clien, IMapper mapper);
    IRestClient GetRestClient(string apikey, RequestModel model);
}