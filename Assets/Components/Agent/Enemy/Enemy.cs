using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IAttackable
{
    public int Health { get; set; }

    public int AttackAmount { get; set; }

    public void Attack()
    {


    }

    public void Die()
    {
        
    }

    public void TakeDamage(IAttackable attacker)
    {
        
    }
}
