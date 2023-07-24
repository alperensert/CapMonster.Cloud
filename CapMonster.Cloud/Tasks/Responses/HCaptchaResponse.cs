using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class HCaptchaResponse : ReCaptchaV2Response
{
    [JsonRequired]
    [JsonProperty("respKey")]
    public string ResponseKey { get; init; } = null!;
    
    [JsonRequired]
    [JsonProperty("userAgent")]
    public string UserAgent { get; init; } = null!;
}