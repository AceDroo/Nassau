using Sakura.Units;
using Sakura.Weapons;

namespace Sakura.Actions;

public class Shoot : ICombatAction
{
    private readonly IUnit _enemy;
    private readonly IRandomService _random;

    public Shoot(IUnit enemy, IRandomService randomService)
    {
        _enemy = enemy;
        _random = randomService;
    }

    public void Execute(IUnit target)
    {
        if (CanHit(_enemy.Stats["Aim"].Value))
        {
            var gun = _enemy.Weapon as Gun;
            gun?.Use(target);
        }
        else
        {
            //_logger.Log($"{_enemy.Name} misses {target.Name}.");
        }
    }

    private bool CanHit(int aim)
    {
        var hitChance = aim * 10;
        var roll = _random.Next(0, 100);
        return roll <= hitChance;
    }
}