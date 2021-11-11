using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Entity
{
    [SerializeField]
    private PlayerData _playerData;

    private PlayerInputActions _inputActions;

    private Vector2 _inputVector = new Vector2();

    private Joystick _joystick; 

    public bool InputPressed
    {
        get
        {
            if (_joystick != null)
                return _joystick.IsPressed();
            else
                return false;
        }
    }

    public Vector2 InputVector
    {
        get => _inputVector;
    }
   

    public override void Awake()
    {
        _inputActions = new PlayerInputActions();
        base.Awake();

        _entityData = _playerData;
        _health = _entityData.MaxHealth;        


        var waitState = new WaitTimeState(3);
        var idleState = new PlayerIdleState(_rb);
        var moveState = new MoveByJoystickState(this, _rb, _entityData);
        var attackState = new AttackState(this, _rb, _weaponManager, _targetDetector, _entityData);
        var deathState = new PlayerDeathState(this);

        _stateMachine.AddTransition(waitState, idleState, () => waitState.TimesUp);

        _stateMachine.AddTransition(idleState, moveState,() => InputPressed);
        _stateMachine.AddTransition(idleState, attackState, () => _targetDetector.Target != null && !InputPressed);

        _stateMachine.AddTransition(moveState, idleState, () => !InputPressed && _targetDetector.Target == null);
        _stateMachine.AddTransition(moveState, attackState, () => !InputPressed && _targetDetector.Target != null);

        _stateMachine.AddTransition(attackState, moveState, () => InputPressed);
        _stateMachine.AddTransition(attackState, idleState, () => _targetDetector.Target == null && !InputPressed);

        _stateMachine.AddAnyTransition(deathState, IsDead);

        _stateMachine.SetState(waitState);
    }

    private void OnEnable()
    {
        _inputActions.Controls.Move.performed += ReadInput;
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Controls.Move.performed -= ReadInput;
        _inputActions.Disable();
    }

    private void ReadInput(InputAction.CallbackContext ctxt)
    {
        UpdateJoystick(ctxt);
        _inputVector = ctxt.ReadValue<Vector2>();        
    }

    private void UpdateJoystick(InputAction.CallbackContext ctxt)
    {  
        var control = ctxt.control.device;
        _joystick = control as Joystick;
    }
}
