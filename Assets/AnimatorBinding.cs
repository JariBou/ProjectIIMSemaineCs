using System.Collections;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _attackClip;
    [SerializeField] private PlayerMove _playerMove;

    private static readonly int GetHit = Animator.StringToHash("GetHit");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Attack = Animator.StringToHash("Attack");

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_playerMove.IsAttacking) return;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(_playerMove.JoystickDirection.x, 0, _playerMove.JoystickDirection.y));

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
    }
    
    private IEnumerator MovementReEnableDelay()
    {
        yield return new WaitForSeconds(_attackClip.length);
        PlayerMove.StopAttack();
    }

    private void StartAttack()
    {
        _animator.SetTrigger(Attack);
        StartCoroutine(MovementReEnableDelay());
    }

    private void HealthUpdate(int amount)
    {
        if (amount < 0)
        {
            _animator.SetTrigger(GetHit);
        }
    }

    private void PlayerStartMove()
    {
        _animator.SetBool(Walking, true);
    }
    
    private void PlayerStopMove()
    {
        _animator.SetBool(Walking, false);
    }
    
    private void OnEnable()
    {
        PlayerMove.OnHealthUpdate += HealthUpdate;
        PlayerMove.OnStartMove += PlayerStartMove;
        PlayerMove.OnStopMove += PlayerStopMove;
        PlayerMove.OnAttack += StartAttack;
    }

    private void OnDisable()
    {
        PlayerMove.OnHealthUpdate -= HealthUpdate;
        PlayerMove.OnStartMove -= PlayerStartMove;
        PlayerMove.OnStopMove -= PlayerStopMove;
        PlayerMove.OnAttack -= StartAttack;
    }
}
