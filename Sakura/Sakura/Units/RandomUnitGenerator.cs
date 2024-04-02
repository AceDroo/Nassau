using Sakura.Extensions;
using Sakura.Races;
using Sakura.Status;

namespace Sakura.Units;

public class RandomUnitGenerator(IRaceDataProvider dataProvider, Random random)
{
    public Unit Generate()
    {
        var race = random.Choose(dataProvider.GetAll());

        return new Unit(
            CreateIdentity(race),
            CreateStats(race),
            CreateAppearance(race)
        );
    }

    private UnitIdentity CreateIdentity(Race race)
    {
        return new UnitIdentity(
            random.Choose(race.FirstNames), 
            random.Choose(race.LastNames),
            string.Empty,
            random.Choose(race.Genders),
            race.RaceName
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

    private UnitAppearance CreateAppearance(Race race)
    {
        return new UnitAppearance(0, 0, 0, 0, 0);
    }
}