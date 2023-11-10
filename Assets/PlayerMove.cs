using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _attack;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    
    public bool IsAttacking { get; private set; }
    // Event pour les dev
    public static event Action OnStartMove;
    public static event Action OnStopMove;
    public static event Action OnAttack;
    public static event Action OnStopAttack;
    public static event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] private UnityEvent _onEvent;
    [SerializeField] private UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    private Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        
    }

    private void StartMove(InputAction.CallbackContext callbackContext)
    {
        JoystickDirection = callbackContext.ReadValue<Vector2>().normalized;
        OnStartMove?.Invoke();
    }
    
    private void StopMove(InputAction.CallbackContext callbackContext)
    {
        JoystickDirection = Vector2.zero;
        OnStopMove?.Invoke();
    }
    
    private void Attack(InputAction.CallbackContext obj)
    {
        IsAttacking = true;
        OnAttack?.Invoke();
    }
    
    private void StopAttacking()
    {
        IsAttacking = false;
    }

    private void FixedUpdate()
    {
        if (IsAttacking)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
        
        Vector2 JoystickSpedAndDeltaTimed = JoystickDirection * (Time.fixedDeltaTime * _speed);
        
        Vector3 planeDisplacement = new(JoystickSpedAndDeltaTimed.x, _rb.velocity.y, JoystickSpedAndDeltaTimed.y);
        
        _rb.velocity = planeDisplacement;
        
    }
    
    private void OnEnable()
    {
        _move.action.performed += StartMove;
        _move.action.canceled += StopMove;
        _attack.action.performed += Attack;
        OnStopAttack += StopAttacking;
    }

    private void OnDisable()
    {
        _move.action.performed -= StartMove;
        _move.action.canceled -= StopMove;
        _attack.action.performed -= Attack;
        OnStopAttack -= StopAttacking;

    }

    public static void StopAttack()
    {
        OnStopAttack?.Invoke();
    }
}
