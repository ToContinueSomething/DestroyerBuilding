using System;
using UnityEngine;

namespace Sources.Handlers
{
    public class ClickHandler : MonoBehaviour
    {
        public event Action<Vector3> Clicked;

        public void Click(Vector3 clickPosition)
        {
            Clicked?.Invoke(clickPosition);
        }
    }
}
