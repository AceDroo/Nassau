using FluentAssertions;
using NSubstitute;
using Sakura.Geoscape;

namespace Sakura.Tests.Geoscape;

[TestFixture]
[TestOf(typeof(DaySchedule))]
public class DayScheduleShould
{
    [Test]
    public void Return_Empty_List_If_No_Activities_Recorded()
    {
        var schedule = new DaySchedule(new DateTime(2024, 1, 1), []);

        schedule.Activities.Should().BeEmpty();
    }

    [Test]
    public void Successfully_Add_Activity()
    {
        var schedule = new DaySchedule(new DateTime(2024, 1, 1), []);

        var activity = Substitute.For<IScheduleActivity>();
        schedule.Add(activity);

        schedule.Activities.Should().Contain(activity);
    }
}