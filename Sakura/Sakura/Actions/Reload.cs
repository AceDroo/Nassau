using Sakura.Units;
using Sakura.Weapons;

namespace Sakura.Actions;

public class Reload : ICombatAction
{
    public void Execute(IUnit unit)
    {
        var gun = unit.Weapon as Gun;
        gun?.Reload();
    }
}