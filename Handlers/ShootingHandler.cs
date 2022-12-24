using System;
using Sources.Handlers;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] private CollisionPossibleHandler _collisionPossibleHandler;
    [SerializeField] private Rocket _rocket;

    public event Action<Vector3,Vector3> Shooted;

    private void OnEnable()
    {
        _collisionPossibleHandler.Collided += OnCollided;
    }

    private void OnDisable()
    {
        _collisionPossibleHandler.Collided += OnCollided;
    }

    private void OnCollided(Vector3 point)
    {
        if (_rocket.TryShoot())
        {
            Shooted?.Invoke(_rocket.MuzzlePosition,point);
        }
    }
}
