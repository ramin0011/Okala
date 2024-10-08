using System.Net;
using Okala.Api.App.Applications.Dtos;
using Okala.Api.App.Applications.Dtos.CryptoApi;
using RestSharp;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace Okala.Api.App.Services;

[ExposeServices(typeof(ICryptoService))]
public class CryptoService(IJsonSerializer jsonSerializer, IConfiguration configuration)
    : ICryptoService, ITransientDependency
{
    public async Task<ResponseModel<CryptoQuote>> GetQuotes(QuotesRequestModel model)
    {
        try
        {
            var client = new RestClient(configuration.GetSection("crypto-endpoint").Value);
            var request = new RestRequest("/crypto", Method.Post);
            request.AddJsonBody(jsonSerializer.Serialize(model));
            var response = await client.ExecuteAsync(request);
            HandleBadRequest(response);
            return HandleResponse(response);
        }
        catch (HttpRequestException e)
        {
            throw new UserFriendlyException("Problem in The Api Connection Request");
        }
    
    }

    private ResponseModel<CryptoQuote> HandleResponse(RestResponse response)
    {
        return response.IsSuccessStatusCode && !response.Content.IsNullOrWhiteSpace()
            ? jsonSerializer.Deserialize<ResponseModel<CryptoQuote>>(response.Content)
            : throw new UserFriendlyException("Problem in The Api Connection Request");
    }

    private void HandleBadRequest(RestResponse response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest && !response.Content.IsNullOrWhiteSpace())
        {
           var result= jsonSerializer.Deserialize<BadRequestResponseModel>(response.Content);
            throw new UserFriendlyException(result.Errors.Code.Aggregate((a,b)=>$"{a},{b}"));
        }
        if(response.StatusCode == HttpStatusCode.BadRequest)
            throw new UserFriendlyException("Problem in The Api Connection Request Body");
    }
}