namespace Sakura;

public class Option<T>
{
    private T? _value;

    public static Option<T> Some(T obj) => new() { _value = obj };
    public static Option<T> None() => new();

    public Option<TResult> Map<TResult>(Func<T, TResult> map) =>
        _value is null ? Option<TResult>.None() : Option<TResult>.Some(map(_value));

    public T Reduce(T orElse) => _value ?? orElse;
}