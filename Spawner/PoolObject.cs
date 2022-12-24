using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Factory
{
    public class PoolObject<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private int _count;

        private List<T> _pool;

        protected void Init(T template)
        {
            _pool = new List<T>();

            for (int i = 0; i < _count; i++)
            {
                var spawned = Instantiate<T>(template, _container);
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }

        protected bool TryGetDisabledObject(out T result)
        {
            result = _pool.FirstOrDefault(obj => obj.gameObject.activeSelf == false);

            return result != null;
        }

        protected void DestroyObject(T template)
        {
            _pool.Remove(template);
            Destroy(template.gameObject);
        }
    }
}
