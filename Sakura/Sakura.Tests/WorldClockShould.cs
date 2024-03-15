using FluentAssertions;

namespace Sakura.Tests;

[TestFixture]
public class WorldClockShould
{
    private WorldClock _clock;

    [SetUp]
    public void Setup()
    {
        _clock = new WorldClock(new DateTime(2030, 1, 1));
    }

    [Test]
    public void Start_On_First_Date()
    {
        _clock.CurrentTime.Should().Be(new DateTime(2030, 1, 1, 0, 0, 0));
    }

    [Test]
    public void Go_To_Next_Minute()
    {
        using var clockMonitor = _clock.Monitor();
        var expectedDate = new DateTime(2030, 1, 1, 0, 1, 0);

        _clock.NextMinute();

        _clock.CurrentTime.Should().Be(expectedDate);
        clockMonitor
            .Should().Raise("TimeUpdated")
            .WithSender(_clock)
            .WithArgs<TimeUpdatedArgs>(args => args.UpdatedDateTime == expectedDate);
    }

    [Test]
    public void Go_To_Next_Hour()
    {
        using var clockMonitor = _clock.Monitor();
        var expectedDate = new DateTime(2030, 1, 1, 1, 0, 0);

        _clock.NextHour();

        _clock.CurrentTime.Should().Be(expectedDate);
        clockMonitor
            .Should().Raise("TimeUpdated")
            .WithSender(_clock)
            .WithArgs<TimeUpdatedArgs>(args => args.UpdatedDateTime == expectedDate);
    }

    [Test]
    public void Go_To_Next_Day()
    {
        using var clockMonitor = _clock.Monitor();
        var expectedDate = new DateTime(2030, 1, 2, 0, 0, 0);

        _clock.NextDay();

        _clock.CurrentTime.Should().Be(expectedDate);
        clockMonitor
            .Should().Raise("TimeUpdated")
            .WithSender(_clock)
            .WithArgs<TimeUpdatedArgs>(args => args.UpdatedDateTime == expectedDate);
    }
}