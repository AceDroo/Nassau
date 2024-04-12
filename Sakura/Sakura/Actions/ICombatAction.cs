using Sakura.Units;

namespace Sakura.Actions;

public interface ICombatAction
{
    void Execute(IUnit unit);
}