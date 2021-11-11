using UnityEngine;
public class PlayerIdleState : IState
{
    private Rigidbody _rb;

    public PlayerIdleState(Rigidbody rb)
    {
        _rb = rb;
    }

    public void OnEnter()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
    }
}
