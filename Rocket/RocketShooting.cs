using System;
using System.Collections;
using RayFire;
using Sources.Interfaces;
using UnityEngine;

namespace Sources.Rocket
{
    public class RocketShooting : MonoBehaviour
    {
        private int _bullets;

        private float _elapsedTime;
        private float _delay;
        private bool _canShoot = false;

        public event Action Shooted;
        public event Action<int> BulletChanged;


        public void Init(int bullets, float delay)
        {
            _bullets = bullets;
            BulletChanged?.Invoke(bullets);
            _delay = delay;
            _elapsedTime = _delay;

            StartCoroutine(MeasureDelay());
        }


        public bool TryShoot()
        {
            if (_canShoot == false && _bullets <= 0)
                return false;

                _bullets--;
                BulletChanged?.Invoke(_bullets);

                _canShoot = false;

                Shooted?.Invoke();

                return true;
        }

        private IEnumerator MeasureDelay()
        {
            while (_bullets > 0)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= _delay)
                {
                    _canShoot = true;
                    _elapsedTime = 0;
                }

                yield return null;
            }
        }
    }
}
