using FluentAssertions;
using NSubstitute;
using Sakura.Geoscape;

namespace Sakura.Tests.Geoscape;

[TestFixture]
[TestOf(typeof(ScheduleManager))]
public class ScheduleManagerShould
{
    [Test]
    public void Return_Empty_List_If_No_Activities_Scheduled_For_Given_Day()
    {
        var manager = new ScheduleManager();

        manager.GetActivities(new DateTime(2024, 10, 10)).Should().BeEmpty();
    }

    [Test]
    public void Successfully_Add_Activity_To_Schedule()
    {
        var manager = new ScheduleManager();

        var dateTime = new DateTime(2024, 1, 1);
        var activity = Substitute.For<IScheduleActivity>();
        manager.AddActivity(dateTime, activity);

        manager.GetActivities(dateTime).Should().Contain(activity);
    }

    [Test]
    public void Successfully_Add_Multiple_Activities_To_Schedule()
    {
        var manager = new ScheduleManager();

        var dateTime = new DateTime(2024, 3, 9);
        var activity1 = Substitute.For<IScheduleActivity>();
        var activity2 = Substitute.For<IScheduleActivity>();
        var activity3 = Substitute.For<IScheduleActivity>();

        manager.AddActivity(dateTime, activity1);
        manager.AddActivity(dateTime, activity2);
        manager.AddActivity(dateTime, activity3);

        manager.GetActivities(dateTime).Should().ContainInOrder(activity1, activity2, activity3);
    }

    [Test]
    public void Successfully_Add_Multiple_Activities_Across_Multiple_Dates_To_Schedule()
    {
        var manager = new ScheduleManager();

        var dateTime1 = new DateTime(2024, 3, 9);
        var activity1 = Substitute.For<IScheduleActivity>();
        var activity2 = Substitute.For<IScheduleActivity>();
        var activity3 = Substitute.For<IScheduleActivity>();

        var dateTime2 = new DateTime(2024, 1, 3);
        var activity4 = Substitute.For<IScheduleActivity>();
        var activity5 = Substitute.For<IScheduleActivity>();

        manager.AddActivity(dateTime1, activity1);
        manager.AddActivity(dateTime1, activity2);
        manager.AddActivity(dateTime1, activity3);
        manager.AddActivity(dateTime2, activity4);
        manager.AddActivity(dateTime2, activity5);

        manager.GetActivities(dateTime1).Should().ContainInOrder(activity1, activity2, activity3);
        manager.GetActivities(dateTime2).Should().ContainInOrder(activity4, activity5);
    }
}