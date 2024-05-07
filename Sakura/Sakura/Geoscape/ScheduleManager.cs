namespace Sakura.Geoscape;

public class ScheduleManager
{
    private readonly Dictionary<DateTime, DaySchedule> _activities = new();

    public void AddActivity(DateTime dateTime, IScheduleActivity scheduleActivity)
    {
        if (_activities.TryGetValue(dateTime, out var activities))
        {
            activities.Add(scheduleActivity);
        }
        else
        {
            _activities.Add(dateTime, new DaySchedule(dateTime, [ scheduleActivity ]));
        }
    }

    public IEnumerable<IScheduleActivity> GetActivities(DateTime dateTime) => 
        _activities.TryGetValue(dateTime, out var schedule) ? schedule.Activities : [];
}