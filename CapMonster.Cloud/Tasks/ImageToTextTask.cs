using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;

namespace CapMonster.Cloud.Tasks;

/// <summary>
/// This task type is used to recognize image captcha.
/// </summary>
public class ImageToTextTask : ITask
{
    /// <summary>
    /// Task's type.
    /// </summary>
    [JsonProperty("type")]
    private readonly string _type = "ImageToTextTask";

    /// <summary>
    /// Base64 encoded content of the image (without line breaks)
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Specifies the module. Currently, the supported modules are common and queue it.
    /// </summary>
    [JsonProperty("CapMonsterModule")]
    public string? Module { get; set; }

    /// <summary>
    /// Captcha recognition threshold with a possible value from 0 to 100. For example, <br/>
    /// if recognizingThreshold was set to 90 and the task was solved with a confidence of 80, you won't be charged. 
    /// </summary>
    /// <value>0-100</value>
    [JsonProperty("recognizingThreshold")]
    public int? RecognizingThreshold { get; set; }

    /// <summary>
    /// Case sensitive or not
    /// </summary>
    [JsonProperty(nameof(Case))]
    public bool? Case { get; set; }
    
    /// <summary>
    /// 1 - if captcha contains numbers only
    /// </summary>
    [JsonProperty("numeric")]
    public int Numeric { get; set; }

    /// <summary>
    /// <b>true</b> if captcha requires a mathematical operation (for example: captcha 2 + 6 = will return a value of 8)
    /// </summary>
    [JsonProperty("math", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    public bool? Math { get; set; }

    /// <summary>
    /// Prepare an image to text task.
    /// </summary>
    /// <param name="body">Base64 encoded content of the image (without line breaks)</param>
    /// <param name="module">Specifies the module. Currently, the supported modules are common and queue it.</param>
    /// <param name="recognizingThreshold">
    ///     Captcha recognition threshold with a possible value from 0 to 100. For example, <br/>
    ///     if recognizingThreshold was set to 90 and the task was solved with a confidence of 80, you won't be charged. 
    /// </param>
    /// <param name="caseSensitive">Case sensitive or not</param>
    /// <param name="numeric">true - if captcha contains numbers only</param>
    /// <param name="math"><b>true</b> if captcha requires a mathematical operation (for example: captcha 2 + 6 = will return a value of 8)</param>
    public ImageToTextTask(string body, string? module = null, int? recognizingThreshold = null, 
        bool? caseSensitive = null, bool? numeric = null, bool? math = null)
    {
        Body = body;
        Module = module;
        RecognizingThreshold = recognizingThreshold;
        Case = caseSensitive;
        Numeric = numeric == true ? 1 : 0;
        Math = math;
    }
}