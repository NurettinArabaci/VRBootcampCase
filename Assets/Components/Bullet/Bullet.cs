using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attack;

    public int AttackAmount
    {
        get => _attack;

        set => _attack = value;
    }

    public void Attack()
    {
        
    }
}
