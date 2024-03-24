namespace Sakura.Geoscape;

public class WorldClock(DateTime currentTime)
{
    public event EventHandler<TimeUpdatedArgs> TimeUpdated;

    public void NextMinute()
    {
        currentTime = currentTime.AddMinutes(1);
        OnTimeUpdated(new TimeUpdatedArgs(currentTime));
    }

    public void NextHour()
    {
        currentTime = currentTime.AddHours(1);
        OnTimeUpdated(new TimeUpdatedArgs(currentTime));
    }

    public void NextDay()
    {
        currentTime = currentTime.AddDays(1);
        OnTimeUpdated(new TimeUpdatedArgs(currentTime));
    }

    public DateTime CurrentTime => currentTime;

    protected virtual void OnTimeUpdated(TimeUpdatedArgs eventArgs)
    {
        TimeUpdated?.Invoke(this, eventArgs); // TODO: Use Event Bus
    }
}