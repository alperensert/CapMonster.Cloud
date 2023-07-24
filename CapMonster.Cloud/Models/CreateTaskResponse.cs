using Newtonsoft.Json;

namespace CapMonster.Cloud.Models;

public class CreateTaskResponse : ErrorResponse
{
    [JsonRequired]
    [JsonProperty("taskId")]
    public int TaskId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; } = null!;
}