using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class ReCaptchaV2Response : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("gRecaptchaResponse")]
    public string GReCaptchaResponse { get; init; } = null!;
}