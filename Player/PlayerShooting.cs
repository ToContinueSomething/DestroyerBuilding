using System;
using Sources.Interfaces;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private Rocket _rocket;

    public event Action Shooted;

    public event Action<int> BulletChanged;

    private void OnEnable()
    {
        _rocket.Shooted += OnShooted;
        _rocket.BulletChanged += OnBulletChanged;
    }

    private void OnShooted()
    {
        Shooted?.Invoke();
    }

    private void OnDisable()
    {
        _rocket.Shooted -= OnShooted;
        _rocket.BulletChanged -= OnBulletChanged;
    }

    private void OnBulletChanged(int bullets)
    {
        BulletChanged?.Invoke(bullets);
    }
}
