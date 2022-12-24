using UnityEngine;

namespace Sources.Interfaces
{
    public interface IShootable
    {
        bool TryShoot(Vector3 from);
    }
}
