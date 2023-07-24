using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks.Responses;

public class ImageToTextResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("text")]
    public string Text { get; init; } = null!;
}