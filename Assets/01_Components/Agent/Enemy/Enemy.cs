using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;

public class Enemy : MonoBehaviour, IDamageable, IAttackable
{
    [SerializeField] private int _health = 100;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    [SerializeField] private int _attack = 50;
    public int AttackAmount
    {
        get => _attack;
        set => _attack = value;
    }

    Transform player;
    public void Attack()
    {
        // start attack animation
    }

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;

        this.UpdateAsObservable().Subscribe(_ => _navMeshAgent.SetDestination(player.position));

    }

   

    public void Die()
    {
        ObjectPooling.Instance.BackToPool(this.gameObject, "enemy");
    }

    public void GetDamage(IAttackable attacker)
    {
        Health -= attacker.AttackAmount;

        if (Health <= 0)
        {
            Die();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IAttackable attacker))
        {
            attacker.Attack();
            GetDamage(attacker);
        }

        if (other.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("Damageable in here");
        }
    }
}
