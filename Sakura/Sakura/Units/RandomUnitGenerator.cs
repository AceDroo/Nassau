using Sakura.Extensions;
using Sakura.Races;

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

    private UnitStats CreateStats(Race race)
    {
        return new UnitStats(
            random.Next(race.Health),
            random.Next(race.Accuracy), 
            random.Next(race.Defense), 
            random.Next(race.Speed),
            0,
            0
        );
    }

    private UnitAppearance CreateAppearance(Race race)
    {
        return new UnitAppearance(0, 0, 0, 0, 0);
    }
}