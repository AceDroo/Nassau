namespace Sakura;

public readonly struct Option<T>
{
    private readonly T _value;
    private readonly bool _hasValue;

    private Option(T value)
    {
        _value = value;
        _hasValue = true;
    }

    public bool IsPresent() => _hasValue;

    public T Get()
    {
        if (IsPresent()) return _value;
        throw new InvalidOperationException("Maybe does not contain a value.");
    }
    
    public static Option<T> Some(T value) => new(value);

    public static Option<T> None() => default;

    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return _hasValue ? some(_value) : none();
    }

    public Option<T> IfNone(Func<T> defaultValueProvider)
    {
        return Match(
            some: Some,
            none: () => Some(defaultValueProvider())
        );
    }

    public Option<TResult> Then<TResult>(Func<T, TResult> func)
    {
        return Match(
            some: value => Option<TResult>.Some(func(value)),
            none: Option<TResult>.None
        );
    }

    public Option<TResult> Map<TResult>(Func<T, TResult> map) => _value is null ? Option<TResult>.None() : Option<TResult>.Some(map(_value));

    public T Reduce(T orElse) => _value ?? orElse;
}