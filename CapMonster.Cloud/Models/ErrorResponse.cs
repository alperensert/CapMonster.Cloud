using Newtonsoft.Json;

namespace CapMonster.Cloud.Models;

public class ErrorResponse
{
    [JsonProperty("errorId")]
    public int ErrorId { get; set; }

    [JsonProperty("errorCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? ErrorCode { get; set; }

    [JsonProperty("errorDescription", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? ErrorDescription { get; set; }
}