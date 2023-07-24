using CapMonster.Cloud.Models;
using CapMonster.Cloud.Tasks;
using CapMonster.Cloud.Tasks.Responses;

namespace CapMonster.Cloud.Tests;

public class TaskTests
{
    [Fact]
    public async void ImageToText_Test()
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        var imageBytes = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "/Resources/imagetotext.png");
        var task = new ImageToTextTask(Convert.ToBase64String(imageBytes), recognizingThreshold: 99);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<ImageToTextResponse>(id);
        Assert.NotNull(response.Text);
        Assert.IsType<string>(response.Text);
    }
    
    [Theory]
    [InlineData("https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high", "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd")]
    [InlineData("https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high", "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd", true)]
    public async void ReCaptchaV2_Test(string websiteUrl, string websiteKey, bool useProxy = false)
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        UseProxy(client, useProxy);
        var task = new ReCaptchaV2Task(websiteUrl, websiteKey);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<ReCaptchaV2Response>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
    }
    
    [Theory]
    [InlineData("https://lessons.zennolab.com/captchas/recaptcha/v3.php?level=beta", "6Le0xVgUAAAAAIt20XEB4rVhYOODgTl00d8juDob")]
    [InlineData("https://lessons.zennolab.com/captchas/recaptcha/v3.php?level=beta", "6Le0xVgUAAAAAIt20XEB4rVhYOODgTl00d8juDob", true)]
    public async void ReCaptchaV3_Test(string websiteUrl, string websiteKey, bool useProxy = false)
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        UseProxy(client, useProxy);
        var task = new ReCaptchaV3Task(websiteUrl, websiteKey);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<ReCaptchaV3Response>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
    }
    
    [Theory]
    [InlineData("https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC", "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC")]
    [InlineData("https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC", "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC", true)]
    public async void FunCaptcha_Test(string websiteUrl, string websiteKey, bool useProxy = false)
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        UseProxy(client, useProxy);
        var task = new FunCaptchaTask(websiteUrl, websiteKey);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<FunCaptchaResponse>(id);
        Assert.NotNull(response.Token);
        Assert.IsType<string>(response.Token);
    }
    
    [Theory]
    [InlineData("https://lessons.zennolab.com/captchas/hcaptcha/?level=easy", "472fc7af-86a4-4382-9a49-ca9090474471")]
    [InlineData("https://lessons.zennolab.com/captchas/hcaptcha/?level=easy", "472fc7af-86a4-4382-9a49-ca9090474471", true)]
    public async void HCaptcha_Test(string websiteUrl, string websiteKey, bool useProxy = false)
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        UseProxy(client, useProxy);
        var task = new FunCaptchaTask(websiteUrl, websiteKey);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<HCaptchaResponse>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
        Assert.NotNull(response.ResponseKey);
        Assert.IsType<string>(response.ResponseKey);
        Assert.NotNull(response.UserAgent);
        Assert.IsType<string>(response.UserAgent);
    }
    
    [Theory]
    [InlineData("https://nowsecure.nl", "0x4AAAAAAADnPIDROrmt1Wwj")]
    [InlineData("https://nowsecure.nl", "0x4AAAAAAADnPIDROrmt1Wwj", true)]
    public async void Turnstile_Test(string websiteUrl, string websiteKey, bool useProxy = false)
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        UseProxy(client, useProxy);
        var task = new TurnstileTask(websiteUrl, websiteKey);
        var id = await client.CreateTask(task);
        Assert.IsType<int>(id);
        var response = await client.JoinTaskResult<TurnstileResponse>(id);
        Assert.NotNull(response.Token);
        Assert.IsType<string>(response.Token);
    }

    private static void UseProxy(CapMonsterClient client, bool useProxy)
    {
        if (useProxy)
            client.SetProxy(new Proxy(Environment.GetEnvironmentVariable("PROXY_TYPE")!, 
                Environment.GetEnvironmentVariable("PROXY_ADDRESS")!,
                int.Parse(Environment.GetEnvironmentVariable("PROXY_PORT")!),
                Environment.GetEnvironmentVariable("PROXY_LOGIN")!,
                Environment.GetEnvironmentVariable("PROXY_PASSWORD")!));
    }
}