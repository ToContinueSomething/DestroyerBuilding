using System;
using UnityEngine;

    public class BulletTriggerHandler : MonoBehaviour
    {
        public event Action Collided;

        private void OnTriggerEnter(Collider other)
        {
            Collided?.Invoke();
        }
    }

