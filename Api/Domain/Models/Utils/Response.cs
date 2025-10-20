namespace Api.Domain.Models.Utils;

public class Response<T>
{
    public T? Data { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
    public bool IsSuccess => Errors == null || Errors.Count == 0;
    public bool IsFailure => !IsSuccess;
    public static Response<T> Success(T data) => new() { Data = data };
    public static Response<Unit> Success() => new() { Data = Unit.Value };
    public static Response<T> Failure(Dictionary<string, string[]> errors) => new() { Errors = errors };
}
