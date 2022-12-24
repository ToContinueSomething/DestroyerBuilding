using System;
using Sources.Bullet;
using UnityEngine;

[RequireComponent(typeof(BulletDestroyer))]
public class Bullet : MonoBehaviour
{
    private BulletDestroyer _bulletDestroyer;

    private Rigidbody _rigidbody;
    private Vector3 _target;

    public event Action<Vector3> Destroyed;
    public event Action<Vector3> Started;


    public void Awake()
    {
        _bulletDestroyer = GetComponent<BulletDestroyer>();
    }

    private void OnEnable()
    {
        _bulletDestroyer.Destroyed += OnDestroyed;
    }

    private void OnDisable()
    {
        _bulletDestroyer.Destroyed -= OnDestroyed;
    }

    private void OnDestroyed()
    {
        Destroyed?.Invoke(transform.position);
    }

    public void Init(Vector3 startPosition, Vector3 target)
    {
        _target = target;

        transform.position = startPosition;
        gameObject.SetActive(true);
        Started?.Invoke(target);
    }
}
