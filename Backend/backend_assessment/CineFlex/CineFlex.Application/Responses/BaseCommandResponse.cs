namespace CineFlex.Application.Responses;

public class BaseCommandResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; }
    public T? Value { get; set; }
    public List<string> Errors { get; set; }
}