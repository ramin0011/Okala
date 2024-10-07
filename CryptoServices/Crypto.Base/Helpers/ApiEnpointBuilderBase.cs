using System.Net;

namespace Crypto.Base.Helpers;

public class ApiEnpointBuilderBase
{
    private readonly string BaseUrl ;
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
    
    public virtual string BuildUrl()
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