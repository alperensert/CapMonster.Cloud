using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class TurnstileResponse : ITaskResponse
{
    [JsonProperty("cf_clearance")]
    public string? CfClearance { get; init; }
    
    [JsonProperty("token")]
    public string? Token { get; init; }
}