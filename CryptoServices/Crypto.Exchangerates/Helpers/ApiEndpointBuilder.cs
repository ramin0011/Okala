using Crypto.Base.Helpers;

namespace Crypto.Exchangerates.Helpers;

public class ApiEndpointBuilder : ApiEnpointBuilderBase
{
    private ApiEndpointBuilder(string baseUrl) : base(baseUrl)
    {
    }

    public static ApiEndpointBuilder GetInstance() => new ApiEndpointBuilder("https://api.exchangeratesapi.io/v1/latest");
    public ApiEndpointBuilder AddAccessKey(string key) => (ApiEndpointBuilder)AddQuery("access_key", key);
    public ApiEndpointBuilder AddBaseCode(string code) => (ApiEndpointBuilder)AddQuery("base", code);
    public ApiEndpointBuilder AddSymbols(string[] symbols) => (ApiEndpointBuilder)AddQuery("symbols ", string.Join(",", symbols).Trim());
    public override string BuildUrl()
    {
        AddQuery("format", "1");
        return base.BuildUrl();
    }
}