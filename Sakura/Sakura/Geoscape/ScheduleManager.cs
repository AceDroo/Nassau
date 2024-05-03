namespace Sakura.Geoscape;

public class ScheduleManager
{
    private readonly Dictionary<DateTime, DaySchedule> _activities = new();

    public void AddActivity(DateTime dateTime, IActivity activity)
    {
        if (_activities.TryGetValue(dateTime, out var activities))
        {
            activities.Add(activity);
        }
        else
        {
            _activities.Add(dateTime, new DaySchedule(dateTime, [ activity ]));
        }
    }

    public IEnumerable<IActivity> GetActivities(DateTime dateTime) => 
        _activities.TryGetValue(dateTime, out var schedule) ? schedule.Activities : [];
}