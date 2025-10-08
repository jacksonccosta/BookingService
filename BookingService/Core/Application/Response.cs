namespace Application;

public enum ErrorCodes
{
    NOT_FOUND = 1,
    COLD_NOT_STORE_DATA = 2
}
public class Response
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ErrorCodes? ErrorCode { get; set; }
}
