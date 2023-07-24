using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Models;

public class TaskResponse<T> : ErrorResponse where T : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("status")]
    public string Status { get; set; } = null!;

    [JsonProperty("solution", NullValueHandling = NullValueHandling.Include)]
    public T? Solution { get; set; }

    [JsonProperty("taskId")]
    public int TaskId { get; set; }
}