
public interface IDamageable
{
    public int Health { get; set; }

    void TakeDamage(IAttackable attacker);

    void Die();
}
