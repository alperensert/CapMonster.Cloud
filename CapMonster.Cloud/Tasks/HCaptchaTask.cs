using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

/// <summary>
/// This task type is used to solve HCaptcha.
/// </summary>
public class HCaptchaTask : ITask, IProxyTask, IUserAgentTask
{
    [JsonProperty("type")]
    private readonly string _type = "HCaptchaTask";

    /// <summary>
    /// Address of a webpage with hCaptcha
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// hCaptcha website key
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// Use true for invisible version of h captcha
    /// </summary>
    [JsonProperty("isInvisible", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsInvisible { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Prepare a HCaptcha task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with hCaptcha</param>
    /// <param name="websiteKey">hCaptcha website key</param>
    /// <param name="isInvisible">Use true for invisible version of h captcha</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public HCaptchaTask(string websiteUrl,
                        string websiteKey,
                        bool? isInvisible = null,
                        string? userAgent = null)
    {
        WebsiteUrl = websiteUrl;
        WebsiteKey = websiteKey;
        IsInvisible = isInvisible;
        UserAgent = userAgent;
    }
}