using FluentAssertions;
using TrenchCats.Events;

namespace Sakura.Tests.Events;

[TestFixture]
public class EventBusShould
{
    [Test]
    public void Invoke_All_Handlers_For_Event_When_Publishing()
    {
        var eventBus = new EventBus();
        var handler1Invoked = false;
        var handler2Invoked = false;
        eventBus.Subscribe("testEvent", _ => handler1Invoked = true);
        eventBus.Subscribe("testEvent", _ => handler2Invoked = true);

        eventBus.Publish("testEvent", "Test Data");

        handler1Invoked.Should().BeTrue();
        handler2Invoked.Should().BeTrue();
    }

    [Test]
    public void Only_Invoke_Subscribed_Handlers_For_Event_When_Publishing()
    {
        var eventBus = new EventBus();
        var handler1Invoked = false;
        var handler2Invoked = false;

        Action<object> handler2 = _ => handler2Invoked = true;

        eventBus.Subscribe("testEvent", _ => handler1Invoked = true);
        eventBus.Subscribe("testEvent", handler2);
        eventBus.Unsubscribe("testEvent", handler2);

        eventBus.Publish("testEvent", "Test Data");

        handler1Invoked.Should().BeTrue();
        handler2Invoked.Should().BeFalse();
    }

    [Test]
    public void Do_Nothing_When_Publishing_For_NonExistent_Event()
    {
        var eventBus = new EventBus();

        eventBus.Publish("NoEvent", "Nothing");
    }
}