using Sources.Factory;
using UnityEngine;

public class BulletSpawner : PoolObject<Bullet>
{
    [SerializeField] private Bullet _template;

    private void Start()
    {
        Init(_template);
    }

    public bool TryGetDisabledBullet(out Bullet bullet)
    {
        bullet = null;

        if (TryGetDisabledObject(out Bullet result))
        {
            bullet = result;
            return true;
        }

        return false;
    }

    public void DestroyBullet(Bullet bullet)
    {
         DestroyObject(bullet);
    }
}
