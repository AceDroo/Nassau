namespace Sakura.Geoscape;

public class DaySchedule(DateTime dateTime, List<IActivity> activities)
{
    private readonly DateTime _dateTime = dateTime;

    public void Add(IActivity activity)
    {
        activities.Add(activity);
    }

    public IEnumerable<IActivity> Activities => activities;
}