using System.Text;
using CapMonster.Cloud.Models;
using CapMonster.Cloud.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CapMonster.Cloud;

public class CapMonsterClient
{
    private readonly HttpClient _httpClient;

    private Proxy? _proxy;
    
    private static readonly Uri Host = new Uri("https://api.capmonster.cloud");

    private readonly string _clientKey;

    public CapMonsterClient(string clientKey)
    {
        _clientKey = clientKey;
        _httpClient = new HttpClient()
        {
            BaseAddress = Host
        };
    }
    
    public async Task<int> CreateTask(ITask task)
    {
        var t = new VanillaTask(_clientKey);
        t.UseSoftId();
        string data;
        switch (task)
        {
            case IProxyTask when IsProxyActive():
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                var p = JObject.FromObject(_proxy!);
                p.Merge(to);
                vt["task"] = p;
                data = vt.ToString();
                break;
            }
            case IProxyTask when !IsProxyActive():
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                to["type"] += "Proxyless";
                vt["task"] = to;
                data = vt.ToString();
                break;
            }
            default:
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                vt["task"] = to;
                data = vt.ToString();
                break;
            }
        }
        var r = await CheckResponse<CreateTaskResponse>(await MakeRequest(Endpoints.CreateTask, data));
        return r.TaskId;
    }

    public async Task<double> GetBalanceAsync()
    {
        var data = new VanillaTask(_clientKey);
        var response = await MakeRequest(Endpoints.Balance, JsonConvert.SerializeObject(data));
        var r = await CheckResponse<GetBalance>(response);
        return r.Balance;
    }

    public async Task<bool> ReportIncorrectCaptcha(CaptchaTypes captchaType, int taskId)
    {
        var data = new VanillaTask(_clientKey)
        {
            TaskId = taskId
        };
        var endpoint = captchaType switch
        {
            CaptchaTypes.Image => Endpoints.IncorrectImageCaptcha,
            CaptchaTypes.Token => Endpoints.IncorrectTokenCaptcha,
            CaptchaTypes.ReCaptcha => Endpoints.IncorrectTokenCaptcha,
            CaptchaTypes.HCaptcha => Endpoints.IncorrectTokenCaptcha,
            _ => throw new ArgumentOutOfRangeException(nameof(captchaType), captchaType, null)
        };
        var response = await MakeRequest(endpoint, JsonConvert.SerializeObject(data));
        CheckResponse(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()));
        return true;
    }
    
    public async Task<TaskResponse<T>> GetTaskResultAsync<T>(int taskId) where T : ITaskResponse
    {
        var vt = new VanillaTask(_clientKey)
        {
            TaskId = taskId
        };
        var response = await MakeRequest(Endpoints.TaskResult, JsonConvert.SerializeObject(vt));
        var r = await CheckResponse<TaskResponse<T>>(response);
        return r;
    }
    
    public async Task<T> JoinTaskResult<T>(int taskId, int maximumTime = 120) where T : ITaskResponse
    {
        var vt = new VanillaTask(_clientKey)
        {
            TaskId = taskId
        };
        for (var i = 0; i < maximumTime; i++)
        {
            var response = await MakeRequest(Endpoints.TaskResult, JsonConvert.SerializeObject(vt));
            var r = await CheckResponse<TaskResponse<T>>(response);
            if (IsReady(r) && r.Solution != null)
                return r.Solution;
            await Task.Delay(1000);
        }
        throw new CapMonsterException(-1, "MAXIMUM_TIME_EXCEED", "Maximum time is exceed.");
    }
    
    public bool IsProxyActive() => _proxy != null;

    public void SetProxy(Proxy proxy) => _proxy = proxy;

    public void DisableProxy() => _proxy = null;
    
    private static bool IsReady<T>(TaskResponse<T> response) where T : ITaskResponse => response.Status == "ready";

    private async Task<HttpResponseMessage> MakeRequest(string endpoint, string data)
    {
        var dataString = new StringContent(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response;
        try
        {
            response = await _httpClient.PostAsync(endpoint, dataString);
        }
        catch (Exception)
        {
            throw new CapMonsterException(-1, "UNABLE_TO_MAKE_REQUEST", "Something is happened while making request");
        }
        CheckResponse(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()));
        return response;
    }
    
    private static void CheckResponse(ErrorResponse? response)
    {
        if (response == null)
            throw new CapMonsterException(-1, "NO_RESPONSE", "The response is empty.");
        if (response.ErrorId != 0)
            throw new CapMonsterException(response.ErrorId, response.ErrorCode!, response.ErrorDescription!);
    }
    
    private static async Task<T> CheckResponse<T>(HttpResponseMessage response) where T : ErrorResponse
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
        }
        catch(Exception)
        {
            throw new CapMonsterException(-2, "INVALID_RESPONSE", "The response is not valid.");
        }
    }
}