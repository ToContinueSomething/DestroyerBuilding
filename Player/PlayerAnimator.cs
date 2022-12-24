using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerRotater))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private PlayerRotater _rotater;
    private PlayerShooting _shooting;

    private readonly int _walk = Animator.StringToHash("Walk");
    private readonly int _putGun = Animator.StringToHash("PutGun");
    private readonly int _shot = Animator.StringToHash("Shot");

    private void Awake()
    {
        _shooting = GetComponent<PlayerShooting>();
        _rotater = GetComponent<PlayerRotater>();
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _shooting.Shooted += OnShooted;
        _player.MoveCompleted += OnMoveCompleted;
    }

    private void OnDisable()
    {
        _shooting.Shooted -= OnShooted;
        _player.MoveCompleted -= OnMoveCompleted;
    }

    private void OnShooted() => PlayShot();

    private void PlayShot() => _animator.SetTrigger(_shot);


    private void OnTurned() => _animator.SetBool(_putGun, true);

    private void StopWalk() => _animator.SetBool(_walk, false);

    private void OnMoveCompleted()
    {
        StopWalk();
        enabled = false;
    }
}
