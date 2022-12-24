using System;
using System.Collections;
using DG.Tweening;
using Sources.Interfaces;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotater : MonoBehaviour, IMovable
{
    [SerializeField] private float _rotateSpeed;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Turn(Vector3 mousePosition)
    {
        Ray ray =  _camera.ScreenPointToRay(mousePosition);

        var lookTarget = new Vector3(ray.direction.x, ray.direction.y, ray.direction.z * 2f);
        var normalizeTarget = new Vector3(lookTarget.x, 0f, lookTarget.z);
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(normalizeTarget,transform.up),_rotateSpeed * Time.deltaTime);
    }
}
