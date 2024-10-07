using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Crypto.Shared.Models.ExchangeRate;

public partial class ApiResponse
{
    [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Success { get; set; }

    [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
    public long? Timestamp { get; set; }

    [JsonProperty("base", NullValueHandling = NullValueHandling.Ignore)]
    public string Base { get; set; }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? Date { get; set; }

    [JsonProperty("rates", NullValueHandling = NullValueHandling.Ignore)]
    public Rates? Rates { get; set; }
    [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
    public Error? Error { get; set; }
}

public class Error
{
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }

    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

}

public partial class Rates
{
    [JsonProperty("GBP", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Gbp { get; set; }

    [JsonProperty("USD", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Usd { get; set; }

    [JsonProperty("BRL", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Brl { get; set; }

    [JsonProperty("AUD", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Aud { get; set; }

    [JsonProperty("JPY", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Jpy { get; set; }

    [JsonProperty("EUR", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Eur { get; set; }
}

public partial class ApiResponse
{
    public static ApiResponse FromJson(string json) =>
        JsonConvert.DeserializeObject<ApiResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this ApiResponse self) =>
        JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}