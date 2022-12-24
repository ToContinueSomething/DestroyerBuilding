using System;
using UnityEngine;

[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    private PlayerShooting _shooting;

    public Action MoveCompleted;
    public Action<Vector3> Shooted;

    private void Awake()
    {
        _shooting = GetComponent<PlayerShooting>();
    }

    private void OnDisable()
    {
        MoveCompleted?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Camera camera = Camera.main;

        var ray = camera.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position,ray.direction);
    }
}
