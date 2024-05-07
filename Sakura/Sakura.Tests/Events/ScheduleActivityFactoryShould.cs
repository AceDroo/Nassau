using FluentAssertions;
using NSubstitute;
using Sakura.Geoscape.Events;
using TrenchCats.Events;

namespace Sakura.Tests.Events;

[TestFixture]
[TestOf(typeof(ScheduleActivityFactory))]
public class ScheduleActivityFactoryShould
{
    [Test]
    public void Create_Research_Activity()
    {
        var factory = new ScheduleActivityFactory(Substitute.For<IEventBus>());

        factory.Create(ScheduleEventType.Research, new DateTime()).Should().BeOfType<ResearchEvent>();
    }

    [Test]
    public void Create_Equipment_Arrival_Event()
    {
        var factory = new ScheduleActivityFactory(Substitute.For<IEventBus>());

        factory.Create(ScheduleEventType.EquipmentArrival, new DateTime()).Should().BeOfType<EquipmentArrivalEvent>();
    }

    [Test]
    public void Create_Council_Request_Event()
    {
        var factory = new ScheduleActivityFactory(Substitute.For<IEventBus>());

        factory.Create(ScheduleEventType.CouncilRequest, new DateTime()).Should().BeOfType<CouncilRequestEvent>();
    }

    [Test]
    public void Create_Alien_Abduction_Event()
    {
        var factory = new ScheduleActivityFactory(Substitute.For<IEventBus>());

        factory.Create(ScheduleEventType.AlienAbduction, new DateTime()).Should().BeOfType<AlienAbductionEvent>();
    }

    [Test]
    public void Create_Dialogue_Event()
    {
        var factory = new ScheduleActivityFactory(Substitute.For<IEventBus>());

        factory.Create(ScheduleEventType.Dialogue, new DateTime()).Should().BeOfType<DialogueEvent>();
    }
}