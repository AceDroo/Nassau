using FluentAssertions;
using NSubstitute;
using Sakura.Core;
using Sakura.Races;
using Sakura.Units;
using TrenchCats.Status;

namespace Sakura.Tests;

[TestFixture]
public class RandomUnitGeneratorShould
{
    private RandomUnitGenerator _unitGenerator;
    private IRaceDataProvider _raceDataProvider;
    private Random _random;
    private Race _race;

    [SetUp]
    public void Setup()
    {
        _raceDataProvider = Substitute.For<IRaceDataProvider>();
        _random = Substitute.For<Random>();
        _unitGenerator = new RandomUnitGenerator(_raceDataProvider, _random);

        _race = new Race(
            "Human",
            ["John", "Jane"],
            ["Doe", "Smith"],
            ["Male", "Female"],
            new RangedInt(80, 120),
            new RangedInt(70, 110),
            new RangedInt(60, 100),
            new RangedInt(50, 90));
        _raceDataProvider.GetAll().Returns([_race]);
    }

    [Test]
    public void Generate_Unit()
    {
        _random.Next(0, _race.FirstNames.Length).Returns(0);
        _random.Next(0, _race.LastNames.Length).Returns(1);
        _random.Next(0, _race.Genders.Length).Returns(0);
        _random.Next(80, 120).Returns(100);
        _random.Next(70, 110).Returns(80);
        _random.Next(60, 100).Returns(85);
        _random.Next(50, 90).Returns(76);

        var unit = _unitGenerator.Generate();

        unit.Identity.Should().NotBeNull();
        unit.Identity.FirstName.Should().Be("John");
        unit.Identity.LastName.Should().Be("Doe");
        unit.Identity.Gender.Should().Be("Male");
        unit.Identity.Race.Should().Be("Human");

        unit.Stats.Should().NotBeNull();
        unit.Stats["Health"].Should().BeEquivalentTo(new Stat("Health", 100, 100));
        unit.Stats["Accuracy"].Should().BeEquivalentTo(new Stat("Accuracy", 80, 80));
        unit.Stats["Defense"].Should().BeEquivalentTo(new Stat("Defense", 85, 85));
        unit.Stats["Speed"].Should().BeEquivalentTo(new Stat("Speed", 76, 76));
        unit.Stats["Missions"].Should().BeEquivalentTo(new Stat("Missions", 0, int.MaxValue));
        unit.Stats["Kills"].Should().BeEquivalentTo(new Stat("Kills", 0, int.MaxValue));

        unit.Appearance.Should().NotBeNull();
        unit.Appearance.Should().BeEquivalentTo(new Appearance(0, 0, 0, 0, 0));
    }
}