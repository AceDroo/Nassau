using Sakura.Units;

namespace Sakura.Actions;

public class PsiAttack : ICombatAction
{
    public void Execute(IUnit unit)
    {
        unit.TakeDamage(5);
        //unit.TakeDamage();
        //_logger.Log($"{_enemy.Name} launches a psychic attack at {unit.Name}.");
    }
}