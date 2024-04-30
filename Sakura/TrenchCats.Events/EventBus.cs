namespace TrenchCats.Events;

public class EventBus : IEventBus
{
    private readonly Dictionary<string, HashSet<Action<object>>> _eventHandlers = new();

    public void Subscribe(string eventName, Action<object> handler)
    {
        if (!_eventHandlers.TryGetValue(eventName, out var handlers))
        {
            handlers = new HashSet<Action<object>>();
            _eventHandlers[eventName] = handlers;
        }

        handlers.Add(handler);
    }

    public void Unsubscribe(string eventName, Action<object> handler)
    {
        if (_eventHandlers.TryGetValue(eventName, out var handlers))
        {
            handlers.Remove(handler);
        }
    }

    public void Publish(string eventName, object eventData)
    {
        if (!_eventHandlers.TryGetValue(eventName, out var handlers)) return;
        foreach (var handler in handlers)
        {
            handler(eventData);
        }
    }
}