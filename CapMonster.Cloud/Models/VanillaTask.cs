using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Models;

internal class VanillaTask
{
    /// <summary>
    /// The client key (api key) which belongs to your account
    /// </summary>
    [JsonRequired]
    [JsonProperty("clientKey", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientKey { get; set; }

    [JsonProperty("task", NullValueHandling = NullValueHandling.Ignore)]
    public ITask? Task { get; private set; }

    [JsonProperty("taskId", NullValueHandling = NullValueHandling.Ignore)]
    public int? TaskId { get; set; }

    [JsonProperty("softId", NullValueHandling = NullValueHandling.Ignore)]
    private int? SoftId { get; set; }

    public VanillaTask(string clientKey, ITask? task = null)
    {
        Task = task;
        ClientKey = clientKey;
    }

    public void UseSoftId() => SoftId = 30;
}