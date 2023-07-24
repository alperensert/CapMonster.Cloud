using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class FunCaptchaResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("token")]
    public string Token { get; set; } = null!;
}