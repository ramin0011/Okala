using System.Net;
using System.Runtime.CompilerServices;

namespace Crypto.Base.Helpers;

public class ApiEnpointBuilderBase
{
    private readonly string BaseUrl = "https://api.exchangeratesapi.io/v1/latest";
    private Dictionary<string,string> QueryStrings = new();

    protected ApiEnpointBuilderBase(string baseUrl)
    {
        this.BaseUrl = baseUrl;
    }

    public static ApiEnpointBuilderBase GetInstance(string baseUrl)
    {
        return new ApiEnpointBuilderBase(baseUrl);
    }

    protected ApiEnpointBuilderBase AddQuery(string key, string value)
    {
        QueryStrings.Add(key,value);
        return this;
    }
    
    public string BuildUrl()
    {
        if (QueryStrings.Count == 0)
        {
            return BaseUrl;
        }

        var queryString = string.Join("&", QueryStrings
            .Select(a => $"{WebUtility.UrlEncode(a.Key)}={WebUtility.UrlEncode(a.Value)}"));

        return $"{BaseUrl}?{queryString}";
    }
}