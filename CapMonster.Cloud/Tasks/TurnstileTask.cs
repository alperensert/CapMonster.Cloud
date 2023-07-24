using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

public class TurnstileTask : ITask, IUserAgentTask
{
    [JsonProperty("type")]
    private readonly string _type = "TurnstileTask";

    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }
    
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }
    
    [JsonRequired]
    [JsonProperty("pageAction", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageAction { get; set; }
    
    /// <summary>
    /// cf_clearance - if cookies are required; <br/>
    /// token - if required token from Turnstile
    /// </summary>
    /// <value>cf_clearance or token</value>
    [JsonRequired]
    [JsonProperty("cloudflareTaskType", NullValueHandling = NullValueHandling.Ignore)]
    public string? CloudFlareTaskType { get; set; }
    
    /// <summary>
    /// Base64 encoded html page with captcha. Required if cloudflareTaskType is equal to cf_clearance.
    /// </summary>
    [JsonRequired]
    [JsonProperty("htmlPageBase64", NullValueHandling = NullValueHandling.Ignore)]
    public string? HtmlPageBase64 { get; set; }
    
    /// <summary>
    /// Only the latest UAs from Chrome are supported.
    /// Required if cloudflareTaskType is specified.
    /// </summary>
    [JsonRequired]
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    public TurnstileTask(string websiteUrl, string websiteKey, string? pageAction = null, CloudFlareTaskType? cloudflareTaskType = null,
        string? htmlPageBase64 = null, string? userAgent = null)
    {
        WebsiteKey = websiteKey;
        WebsiteUrl = websiteUrl;
        PageAction = pageAction;
        if (cloudflareTaskType != null)
            UserAgent = userAgent ?? throw new CapMonsterException(12, "USER_AGENT_REQUIRED", "User agent is required if cloudFlareTaskType is specified.");
        if (cloudflareTaskType == Utilities.CloudFlareTaskType.CfClearance)
        {
            HtmlPageBase64 = htmlPageBase64 ?? throw new CapMonsterException(
                12,
                "HTML_PAGE_BASE64_REQUIRED",
                "HtmlPageBase64 is required if cloudFlareTaskType is CFClearance.");
        }
        CloudFlareTaskType = cloudflareTaskType switch
        {
            Utilities.CloudFlareTaskType.CfClearance => "cf_clearance",
            Utilities.CloudFlareTaskType.Token => "token",
            null => null,
            _ => throw new ArgumentOutOfRangeException(nameof(cloudflareTaskType), cloudflareTaskType, null)
        };
    }
}