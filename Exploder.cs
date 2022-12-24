using RayFire;
using UnityEngine;

namespace Sources
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private RayfireGun _gun;
        [SerializeField] private Transform _target;

        public void Init(float strength)
        {
            _gun.strength = strength;
        }

        public void Explode(Vector3 target)
        {
            _target.position = target;
            _gun.target = _target;
            _gun.Shoot();
        }
    }
}
