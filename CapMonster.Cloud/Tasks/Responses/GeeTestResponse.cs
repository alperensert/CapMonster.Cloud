using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class GeeTestResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("challenge")]
    public string Challenge { get; init; } = null!;
    
    [JsonRequired]
    [JsonProperty("validate")]
    public string Validate { get; init; } = null!;
    
    [JsonRequired]
    [JsonProperty("seccode")]
    public string SecCode { get; init; } = null!;
}