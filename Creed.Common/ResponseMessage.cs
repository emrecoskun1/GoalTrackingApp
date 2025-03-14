namespace Creed.Common;

public class ResponseMessage
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public object Data { get; set; }
}