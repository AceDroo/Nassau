namespace TrenchCats.Events;

public interface IEventBus
{
    void Subscribe(string eventName, Action<object> handler);
    void Unsubscribe(string eventName, Action<object> handler);
    void Publish(string eventName, object eventData);
}