using Sakura.Units;
using TrenchCats.Random;

namespace Sakura.Actions;

public class Intimidate : ICombatAction
{
    private readonly IUnit _enemy;
    private readonly IRandomService _randomService;

    public Intimidate(IUnit enemy, IRandomService randomService)
    {
        _enemy = enemy;
        _randomService = randomService;
    }

    public void Execute(IUnit unit)
    {
        if (_randomService.Next(0, 10) < _enemy.Stats["Will"].Value)
        {
            unit.Flags["Panic"] = true;
        }
    }
}