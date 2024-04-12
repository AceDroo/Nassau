using Sakura.Units;

namespace Sakura.Actions;

public class Heal : ICombatAction
{
    private readonly int _amount;

    public Heal(int amount)
    {
        _amount = amount;
    }

    public void Execute(IUnit unit)
    {
        unit.Heal(_amount);
    }
}