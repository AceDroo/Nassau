namespace Sakura.Geoscape;

public class ScheduleManager
{
    private Dictionary<DateTime, List<IActivity>> _activities = new();
    
    public IEnumerable<IActivity> GetActivities(DateTime dateTime)
    {
        return _activities.TryGetValue(dateTime, out var activities) ? activities : [];
    }

    public void AddActivity(DateTime dateTime, IActivity activity)
    {
        if (_activities.TryGetValue(dateTime, out var activities))
        {
            activities.Add(activity);
        }
        else
        {
            _activities.Add(dateTime, [ activity ]);
        }
    }
}