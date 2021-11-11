using UnityEngine;
public class MoveByJoystickState : IState
{
    private Rigidbody _rb;

    private Player _player;

    private float _speed;

    public MoveByJoystickState(Player player, Rigidbody rb, EntityData entityData)
    {
        _player = player;
        _rb = rb;
        _speed = entityData.MovementSpeed;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void Tick()
    {
        if (_rb == null || _player == null) return;
        Vector2 moveVector = _player.InputVector.normalized;
        _rb.velocity = new Vector3 (moveVector.x * _speed * Time.deltaTime, _rb.velocity.y, moveVector.y * _speed * Time.deltaTime);

        _player.transform.forward = new Vector3(moveVector.x, _player.transform.forward.y, moveVector.y);
    }
}
