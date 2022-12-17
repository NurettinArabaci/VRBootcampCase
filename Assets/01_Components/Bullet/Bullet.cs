using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IAttackable
{
    [SerializeField] private int _attack = 50;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _speed;

    private bool _inPool;

    private void OnEnable()
    {
        _inPool = false;
        
    }

    public int AttackAmount
    {
        get => _attack;

        set => _attack = value;
    }

    public void ShootBullet()
    {
        _rb.AddForce(_speed * Vector3.forward, ForceMode.Impulse);
        StartCoroutine(BackToPoolCR());
    }
    public void Attack()
    {
        _inPool = true;
        ObjectPooling.Instance.BackToPool(this.gameObject, "bullet");
    }

    IEnumerator BackToPoolCR()
    {
        float timeCounter = 10f;
        while (!_inPool)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {

                _inPool = true;
                ObjectPooling.Instance.BackToPool(this.gameObject, "bullet");
                yield return null;
            }
        }
    }


}
