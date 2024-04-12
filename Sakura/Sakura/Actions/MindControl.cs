using Sakura.Units;

namespace Sakura.Actions;

public class MindControl : ICombatAction
{
    private readonly IUnit _enemy;

    public MindControl(IUnit enemy)
    {
        _enemy = enemy;
    }

    public void Execute(IUnit unit)
    {
        //_logger.Log("Unit has been mind-controlled!");
    }
}