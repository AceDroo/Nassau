namespace Sakura.Functional;

public readonly struct Result<TSuccess, TError>
{
    public TSuccess Success { get; }
    public TError Error { get; }
    public bool IsError { get; }

    private Result(TSuccess success)
    {
        IsError = false;
        Success = success;
        Error = default!;
    }

    private Result(TError error)
    {
        IsError = true;
        Error = error;
        Success = default!;
    }

    public static Result<TSuccess, TError> Ok(TSuccess success) => new(success);
    public static Result<TSuccess, TError> Err(TError error) => new(error);
}