using System;
using UnityEngine;

namespace Sources.Handlers
{
    public class CollisionPossibleHandler : MonoBehaviour
    {
        [SerializeField] private ClickHandler _clickHandler;

        private Camera _camera;

        public event Action<Vector3> Collided;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _clickHandler.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _clickHandler.Clicked += OnClicked;
        }

        private void OnClicked(Vector3 clickPosition)
        {
            if (TryGetCollisionPoint(out Vector3 point, clickPosition))
            {
                Collided.Invoke(point);
            }
        }

        private bool TryGetCollisionPoint(out Vector3 point, Vector3 mousePosition)
        {
            point = default;

            Ray ray = _camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                point = hit.point;

            return point != default;
        }
    }
}
