using UnityEngine;


public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;


    public Bullet GetDefualtBullet()
    {
        return Instantiate(_bullet);
    }
}
