using System;
using System.Collections;
using RayFire;
using Sources.Interfaces;
using Sources.Rocket;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _muzzle;

    private RocketShooting _rocketShooting;
    public Vector3 MuzzlePosition => _muzzle.position;

    public event Action Shooted;
    public event Action<int> BulletChanged;

    private void Awake()
    {
        _rocketShooting = GetComponent<RocketShooting>();
    }

    private void OnEnable()
    {
        _rocketShooting.Shooted += OnShooted;
        _rocketShooting.BulletChanged +=
            OnBulletChanged;
    }

    private void OnDisable()
    {
        _rocketShooting.Shooted -= OnShooted;
        _rocketShooting.BulletChanged -= OnBulletChanged;
    }

    public void Init(int bullets)
    {
        BulletChanged?.Invoke(bullets);
        _rocketShooting.Init(bullets, _delay);
    }

    public bool TryShoot()
    {
       return _rocketShooting.TryShoot();
    }

    private void OnBulletChanged(int bullets)
    {
        BulletChanged?.Invoke(bullets);
    }

    private void OnShooted()
    {
        Shooted.Invoke();
    }
}
