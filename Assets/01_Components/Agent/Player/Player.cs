using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health = 100;
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public void GetDamage(IAttackable attacker)
    {
        Health -= attacker.AttackAmount;

        if (Health <= 0)
            Die();
        
    }

    public void Die()
    {
        // GameOver
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy attacker))
        {
            attacker.Attack();
            GetDamage(attacker);
        }
    }
}
