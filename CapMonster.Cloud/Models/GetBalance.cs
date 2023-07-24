using Newtonsoft.Json;

namespace CapMonster.Cloud.Models;

public class GetBalance : ErrorResponse
{
    [JsonRequired]
    [JsonProperty("balance", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public double Balance { get; set; }
}