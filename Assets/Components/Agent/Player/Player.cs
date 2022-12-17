using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { get; set; }


    public void TakeDamage(IAttackable attacker)
    {
        
    }

    public void Die()
    {

    }
}
