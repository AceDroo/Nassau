namespace TrenchCats.Functional;

using System;

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

    public TResult Match<TResult>(Func<TSuccess, TResult> onSuccess, Func<TError, TResult> onError) => 
        IsError ? onError(Error) : onSuccess(Success);

    public Result<TNewSuccess, TError> Map<TNewSuccess>(Func<TSuccess, TNewSuccess> map) => 
        IsError ? Result<TNewSuccess, TError>.Err(Error) : Result<TNewSuccess, TError>.Ok(map(Success));

    public T Reduce<T>(Func<TSuccess, T> onSuccess, Func<TError, T> onError) => IsError ? onError(Error) : onSuccess(Success);
}