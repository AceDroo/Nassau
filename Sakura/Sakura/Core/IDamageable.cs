namespace Sakura.Core;

public interface IDamageable
{
    void TakeDamage(int damage);
    void Heal(int amount);
    int CurrentHealth { get; }
}