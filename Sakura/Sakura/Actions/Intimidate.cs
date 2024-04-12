using Sakura.Units;

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
        //_logger.Log($"{_enemy.Name} is attempting to intimidate its target!");
        //if (_randomService.Next(unit.Stats["Will"].Value) < 10) _logger.Log("Soldier has panicked!");
    }
}