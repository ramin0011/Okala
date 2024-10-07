using Crypto.Base.Helpers;

namespace Crypto.Exchangerates.Helpers;

public class ApiEndpointBuilder:ApiEnpointBuilderBase
{
    private ApiEndpointBuilder(string baseUrl) : base(baseUrl) { }
    public static ApiEndpointBuilder GetInstance(string baseUrl)=> new ApiEndpointBuilder(baseUrl);
    public void AddAccessKey(string key)=> AddQuery("access_key", key);
    public void AddBaseCode(string key)=> AddQuery("base", key);
    public void AddSymbols(string[] symbols )=> AddQuery("symbols ", string.Join(",",symbols));
}