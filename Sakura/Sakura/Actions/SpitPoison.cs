using Sakura.Units;

namespace Sakura.Actions;

public class SpitPoison : ICombatAction
{
    private readonly IUnit _enemy;

    public SpitPoison(IUnit enemy)
    {
        _enemy = enemy;
    }

    public void Execute(IUnit unit)
    {
        //_logger.Log("Enemy spits at unit!");
    }
}