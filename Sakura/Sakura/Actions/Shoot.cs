using Sakura.Units;

namespace Sakura.Actions;

public class Shoot : ICombatAction
{
    private readonly IUnit _unit;
    private readonly IRandomService _random;

    public Shoot(IUnit unit, IRandomService randomService)
    {
        _unit = unit;
        _random = randomService;
    }

    public void Execute(IUnit target)
    {
        if (CanHit(_unit.Stats["Aim"].Value))
        {
            _unit.Weapon.Use(target);
        }
        //_logger.Log($"{_enemy.Name} misses {target.Name}.");
    }

    private bool CanHit(int aim)
    {
        var hitChance = aim * 10;
        var roll = _random.Next(0, 100);
        return roll <= hitChance;
    }
}