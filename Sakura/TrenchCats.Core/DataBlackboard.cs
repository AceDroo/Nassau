namespace TrenchCats.Core;

public class DataBlackboard
{
    private readonly Dictionary<string, object> _data = new();

    public void SetData(string key, object value)
    {
        _data[key] = value;
    }

    public T? GetData<T>(string key)
    {
        if (_data.TryGetValue(key, out var value))
        {
            return (T) value;
        }

        return default;
    }
}