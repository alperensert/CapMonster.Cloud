using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

/// <summary>
/// This task type is used to solve the reCaptchaV2 version
/// </summary>
public class ReCaptchaV2Task : ITask, IUserAgentTask, ICookieTask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string _type = "NoCaptchaTask";

    /// <summary>
    /// Address of a webpage with Google ReCaptcha
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// Recaptcha website key. <div class="g-recaptcha" data-sitekey="THAT_ONE"></div>
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// Some custom implementations may contain additional "data-s" parameter in ReCaptcha2 div
    /// </summary>
    [JsonProperty("recaptchaDataSValue", NullValueHandling = NullValueHandling.Ignore)]
    public string? RecaptchaDataSValue { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Additional cookies which we must use during interaction with target page or Google.
    /// </summary>
    [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cookies { get; set; }

    /// <summary>
    /// Prepare a ReCaptchaV2 task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Google ReCaptcha</param>
    /// <param name="websiteKey">Recaptcha website key. <div class="g-recaptcha" data-sitekey="THAT_ONE"></div></param>
    /// <param name="recaptchaDataSValue">Some custom implementations may contain additional "data-s" parameter in ReCaptcha2 div</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    /// <param name="cookies">Additional cookies which we must use during interaction with target page or Google.</param>
    public ReCaptchaV2Task(string websiteUrl,
                           string websiteKey,
                           string? recaptchaDataSValue = null,
                           string? userAgent = null,
                           string? cookies = null)
    {
        WebsiteUrl = websiteUrl;
        WebsiteKey = websiteKey;
        RecaptchaDataSValue = recaptchaDataSValue;
        UserAgent = userAgent;
        Cookies = cookies;
    }
}