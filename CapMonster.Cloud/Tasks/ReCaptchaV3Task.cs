using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

public class ReCaptchaV3Task : ITask
{
    [JsonProperty("type")]
    private readonly string _type = "ReCaptchaV3Task";

    /// <summary>
    /// Address of a webpage with Google ReCaptcha 
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// ReCaptchaV3 website key.
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }
    
    /// <summary>
    /// Widget action value. Website owner defines what user is doing on the page through this parameter. Default value: verify
    /// </summary>
    [JsonRequired]
    [JsonProperty("pageAction", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageAction { get; set; }

    /// <summary>
    /// Value from 0.1 to 0.9
    /// </summary>
    [JsonProperty("minScore", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinimumScore { get; set; }

    /// <summary>
    /// Prepare a ReCaptchaV3 task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Google ReCaptcha </param>
    /// <param name="websiteKey">ReCaptchaV3 website key.</param>
    /// <param name="pageAction">Widget action value. Website owner defines what user is doing on the page through this parameter. Default value: verify</param>
    /// <param name="minimumScore">Value from 0.1 to 0.9</param>
    public ReCaptchaV3Task(string websiteUrl,
                           string websiteKey,
                           string? pageAction = null,
                           double? minimumScore = null)
    {
        WebsiteKey = websiteKey;
        WebsiteUrl = websiteUrl;
        PageAction = pageAction;
        MinimumScore = minimumScore;
    }
}