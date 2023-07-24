namespace CapMonster.Cloud.Tests;

public class BaseMethodTests
{
    [Fact]
    public async void TestBalance()
    {
        var client = new CapMonsterClient(Environment.GetEnvironmentVariable("APIKEY")!);
        var balance = await client.GetBalanceAsync();
        Assert.IsType<double>(balance);
    }
}