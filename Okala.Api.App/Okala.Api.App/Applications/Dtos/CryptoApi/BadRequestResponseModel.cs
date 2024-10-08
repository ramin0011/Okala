namespace Okala.Api.App.Applications.Dtos.CryptoApi
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public  class BadRequestResponseModel
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Type { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public long? Status { get; set; }

        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public Errors Errors { get; set; }

        [JsonProperty("traceId", NullValueHandling = NullValueHandling.Ignore)]
        public string TraceId { get; set; }
    }

    public class Errors
    {
        [JsonProperty("Code", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Code { get; set; }
    }
}