using System;
using UnityEngine;

namespace Sources.Bullet
{
    public class BulletDestroyer : MonoBehaviour
    {
        private BulletTriggerHandler _bulletTriggerHandler;

        public event Action Destroyed;

        private void Awake()
        {
            _bulletTriggerHandler = GetComponent<BulletTriggerHandler>();
        }

        private void OnEnable()
        {
            _bulletTriggerHandler.Collided += OnCollided;
        }

        private void OnDisable()
        {
            _bulletTriggerHandler.Collided -= OnCollided;
        }

        private void OnCollided()
        {
            Destroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
