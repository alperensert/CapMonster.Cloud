namespace CapMonster.Cloud;

internal static class Endpoints
{
    public const string Balance = "/getBalance";
    
    public const string CreateTask = "/createTask";
    
    public const string TaskResult = "/getTaskResult";

    public const string IncorrectImageCaptcha = "/reportIncorrectImageCaptcha";

    public const string IncorrectTokenCaptcha = "/reportIncorrectTokenCaptcha";
}