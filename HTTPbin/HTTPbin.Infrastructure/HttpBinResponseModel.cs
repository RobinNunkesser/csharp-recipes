using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HTTPbin.Infrastructure
{
    public partial class HttpBinResponseModel
    {
        [JsonProperty("args")] public Args Args { get; set; }

        [JsonProperty("headers")] public Headers Headers { get; set; }

        [JsonProperty("origin")] public string Origin { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("json")] public string Json { get; set; }
    }

    public partial class Args
    {
    }

    public partial class Headers
    {
        [JsonProperty("Accept")] public string Accept { get; set; }

        [JsonProperty("Accept-Encoding")]
        public string AcceptEncoding { get; set; }

        [JsonProperty("Accept-Language")]
        public string AcceptLanguage { get; set; }

        [JsonProperty("Host")] public string Host { get; set; }

        [JsonProperty("User-Agent")] public string UserAgent { get; set; }

        [JsonProperty("X-Amzn-Trace-Id")]
        public string XAmznTraceId { get; set; }
    }

    public partial class HttpBinResponseModel
    {
        public static HttpBinResponseModel FromJson(string json) =>
            JsonConvert.DeserializeObject<HttpBinResponseModel>(json,
                Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this HttpBinResponseModel self) =>
            JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles =
                            DateTimeStyles.AssumeUniversal
                    }
                },
            };
    }
}