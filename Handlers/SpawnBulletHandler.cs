using System;
using UnityEngine;

public class SpawnBulletHandler : MonoBehaviour
{
    [SerializeField] private ShootingHandler _ShootingHandler;
    [SerializeField] private BulletFactory _bulletFactory;


    public event Action<Bullet> Spawned;

    private void OnEnable()
    {
        _ShootingHandler.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        _ShootingHandler.Shooted -= OnShooted;
    }

    private void OnShooted(Vector3 from,Vector3 target)
    {
        TrySpawnBullet(from, target);
    }

    private bool TrySpawnBullet(Vector3 from,Vector3 target)
    {
        var bullet =  _bulletFactory.GetDefualtBullet();

        bullet.Init(from,target);

        Spawned?.Invoke(bullet);
        return false;
    }

}
