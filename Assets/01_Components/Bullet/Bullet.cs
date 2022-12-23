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
        ShootBullet();
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
        _rb.velocity = Vector3.zero;
        ObjectPooling.Instance.BackToPool(this.gameObject, "bullet");
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A)) return;
        Debug.Log("Shoot");
        ShootBullet();
    }

    IEnumerator BackToPoolCR()
    {
        float timeCounter = 10f;
        
        while (!_inPool)
        {
            timeCounter -= Time.deltaTime;
            Debug.Log($"time counter: {timeCounter}");
            if (timeCounter <= 0)
            {

                _inPool = true;
                _rb.velocity = Vector3.zero;
                ObjectPooling.Instance.BackToPool(this.gameObject, "bullet");


                yield return null;
            }
            yield return null;
        }
    }


}
