using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

/// <summary>
/// This task is used to solve GeeTest.
/// </summary>
public class GeeTestTask : ITask, IProxyTask, IUserAgentTask, ICookieTask
{
    [JsonProperty("type")]
    private readonly string _type = "GeeTestTask";

    /// <summary>
    /// Address of a webpage with GeeTest
    /// </summary>
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// The domain public key, rarely updated.
    /// </summary>
    [JsonProperty("gt", NullValueHandling = NullValueHandling.Ignore)]
    public string? Gt { get; set; }

    /// <summary>
    /// Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.
    /// </summary>
    [JsonProperty("challenge", NullValueHandling = NullValueHandling.Ignore)]
    public string? Challenge { get; set; }

    /// <summary>
    /// Optional API subdomain. May be required for some implementations.
    /// </summary>
    [JsonProperty("geetestApiServerSubdomain", NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiServerSubdomain { get; set; }
    
    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }
    
    [JsonProperty("initParameters")]
    public object? InitParameters { get; set; }
    
    [JsonProperty("geetestGetLib", NullValueHandling = NullValueHandling.Ignore)]
    public string? GeeTestGetLib { get; set; }
    
    [JsonProperty("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Prepare a GeeTest task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with GeeTest</param>
    /// <param name="gt">The domain public key, rarely updated.</param>
    /// <param name="challenge">Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.</param>
    /// <param name="apiServerSubdomain">Optional API subdomain. May be required for some implementations.</param>
    /// <param name="initParameters">Additional parameters for version 4.</param>
    /// <param name="geeTestGetLib">Optional parameter. May be required for some sites. Send JSON as a string.</param>
    /// <param name="version">Version number (default is 3). Possible values: 3, 4.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public GeeTestTask(string websiteUrl,
                       string? gt = null,
                       string? challenge = null,
                       string? apiServerSubdomain = null,
                       object? initParameters = null,
                       string? geeTestGetLib = null,
                       int? version = null,
                       string? userAgent = null)
    {
        WebsiteUrl = websiteUrl;
        Gt = gt;
        Challenge = challenge;
        ApiServerSubdomain = apiServerSubdomain;
        UserAgent = userAgent;
        Version = version;
        InitParameters = initParameters;
        GeeTestGetLib = geeTestGetLib;
    }
}