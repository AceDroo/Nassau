using Sakura.Units;

namespace Sakura.Actions;

public class MindMerge : ICombatAction
{
    public void Execute(IUnit unit)
    {
        // Todo: Max it also increase the max
        unit.Stats["Health"].Increase(2);
        unit.Stats["Will"].Increase(10);
        //_logger.Log($"{_enemy.Name} uses Mind Merge on {unit.Name}.");
    }
}