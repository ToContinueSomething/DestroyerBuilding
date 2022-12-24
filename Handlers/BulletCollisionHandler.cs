using System;
using System.Collections.Generic;
using Sources;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private SpawnBulletHandler _spawnBulletHandler;
    [SerializeField] private Exploder _exploder;

    private Queue<Bullet> _bullets = new Queue<Bullet>(8);


    public void Explode(Vector3 point)
    {
        _exploder.Explode(point);
    }

    private void OnEnable()
    {
        _spawnBulletHandler.Spawned += OnBulletSpawned;
    }

    private void OnDisable()
    {
        _spawnBulletHandler.Spawned -= OnBulletSpawned;
    }

    private void OnBulletSpawned(Bullet bullet)
    {
        _bullets.Enqueue(bullet);

        bullet.Destroyed += OnBulletCollided;
    }

    private void OnBulletCollided(Vector3 point)
    {
        var bullet = _bullets.Dequeue();
        _exploder.Explode(point);

        bullet.Destroyed -= OnBulletCollided;

    }
}
