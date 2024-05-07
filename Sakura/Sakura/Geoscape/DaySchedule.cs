namespace Sakura.Geoscape;

public class DaySchedule(DateTime dateTime, List<IScheduleActivity> activities)
{
    private readonly DateTime _dateTime = dateTime;

    public void Add(IScheduleActivity scheduleActivity)
    {
        activities.Add(scheduleActivity);
    }

    public IEnumerable<IScheduleActivity> Activities => activities;
}