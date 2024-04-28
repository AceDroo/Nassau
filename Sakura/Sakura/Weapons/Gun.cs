using TrenchCats.Combat;
using TrenchCats.Random;
using TrenchCats.Status;

namespace Sakura.Weapons;

public class Gun : IWeapon
{
    private readonly string _name;
    private readonly Stats _stats;
    private readonly IRandomService _random;

    public Gun(GunStats gunStats, IRandomService random)
    {
        _name = gunStats.Name;
        _random = random;
        _stats = new Stats
        {
            { "Damage", gunStats.MinDamage, gunStats.MaxDamage },
            { "Ammo", gunStats.Ammo }
        };
    }

    public Stats Stats => _stats;

    public void Use(IDamageable target)
    {
        target.TakeDamage(CalculateDamage());
        _stats["Ammo"].Decrease(1);
    }

    private int CalculateDamage()
    {
        var damage = _stats["Damage"];
        return _random.Next(damage.Value, damage.Max);
    }

    public void Reload()
    {
        _stats["Ammo"].Fill();
    }
}