using Sakura.Races;
using Sakura.Ranking;
using TrenchCats.Random;
using TrenchCats.Status;

namespace Sakura.Units;

public class RandomUnitGenerator(IRaceDataProvider dataProvider, Random random) : IUnitGenerator
{
    public IUnit Generate()
    {
        var race = random.Choose(dataProvider.GetAll());

        return new Unit(
            CreateIdentity(race),
            CreateStats(race),
            CreateAppearance(race),
            new Flags()
        );
    }

    private Identity CreateIdentity(Race race)
    {
        return new Identity(
            random.Choose(race.FirstNames), 
            random.Choose(race.LastNames),
            string.Empty,
            random.Choose(race.Genders),
            race.RaceName,
            Rank.Rookie
        );
    }

    private Stats CreateStats(Race race)
    {
        return new Stats
        {
            { "Health", random.Next(race.Health) },
            { "Accuracy", random.Next(race.Accuracy) },
            { "Defense", random.Next(race.Defense) },
            { "Speed", random.Next(race.Speed) },
            { "Missions", 0, int.MaxValue },
            { "Kills", 0, int.MaxValue }
        };
    }

    private Appearance CreateAppearance(Race race)
    {
        return new Appearance(0, 0, 0, 0, 0);
    }
}