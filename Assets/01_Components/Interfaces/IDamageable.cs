
public interface IDamageable
{
    public int Health { get; set; }

    void GetDamage(IAttackable attacker);

    void Die();
}
