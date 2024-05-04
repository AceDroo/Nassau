namespace Sakura.Geoscape;

public class TimeUpdatedArgs(DateTime updatedDateTime) : EventArgs
{
    public DateTime UpdatedDateTime { get; } = updatedDateTime;
}