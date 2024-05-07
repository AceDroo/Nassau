using TrenchCats.Events;

namespace Sakura.Geoscape.Events;

public class ScheduleActivityFactory(IEventBus eventBus)
{
    public IScheduleActivity Create(ScheduleEventType eventType, DateTime occurrenceTime)
    {
        return eventType switch
        {
            ScheduleEventType.Research => new ResearchEvent(occurrenceTime),
            ScheduleEventType.CouncilRequest => new CouncilRequestEvent(occurrenceTime),
            ScheduleEventType.AlienAbduction => new AlienAbductionEvent(occurrenceTime),
            ScheduleEventType.EquipmentArrival => new EquipmentArrivalEvent(occurrenceTime),
            ScheduleEventType.Dialogue => new DialogueEvent(occurrenceTime, eventBus),
            _ => new NoScheduleEvent()
        };
    }
}