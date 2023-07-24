namespace CapMonster.Cloud.Utilities;

public class CapMonsterException : Exception
{
    public int ErrorId { get; set; }

    public string ErrorCode { get; set; }

    public string ErrorDescription { get; set; }

    public CapMonsterException(int errorId, string errorCode, string errorDescription) : base(
        $"[{errorCode}]: {errorDescription}")
    {
        ErrorId = errorId;
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
    }
}