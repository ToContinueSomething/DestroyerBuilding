using System;
using System.Collections;
using UnityEngine;


public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Bullet _bullet;
    private BulletTriggerHandler _triggerHandler;

    private bool _isReached;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
        _triggerHandler = GetComponent<BulletTriggerHandler>();
    }

    private void OnEnable()
    {
        _triggerHandler.Collided += OnCollided;
        _bullet.Started += OnStarted;
    }

    private void OnDisable()
    {
        _triggerHandler.Collided -= OnCollided;
        _bullet.Started -= OnStarted;
    }

    private void OnCollided()
    {
        _isReached = true;
    }

    private void OnStarted(Vector3 target)
    {
        StartCoroutine(Move(target));
    }

    private IEnumerator Move(Vector3 target)
    {
        while (_isReached == false)
        {
            float distance = Vector3.Distance(transform.position, target);
            print(distance);

            if (distance <= Mathf.Epsilon)
              Invoke(nameof(DisableWithDelay),0.2f);

            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void DisableWithDelay()
    {
        gameObject.SetActive(false);
    }
}
