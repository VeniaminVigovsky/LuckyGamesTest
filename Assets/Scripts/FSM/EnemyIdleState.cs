using UnityEngine;
public class EnemyIdleState : IState
{
    private float _startTime;

    private float _idleDuration;

    private bool _transitionToPathfinding;

    private Rigidbody _rb;

    public bool TimesUp
    {
        get => _startTime + _idleDuration < Time.time;
    }

    public bool TransitionToPathFinding
    {
        get => _transitionToPathfinding;
    }

    public EnemyIdleState(Rigidbody rb, EnemyData enemyData)
    {        
        _idleDuration = enemyData.IdleDuration;
        _rb = rb;
    }

    public void OnEnter()
    {
        _startTime = Time.time;
        _transitionToPathfinding = !_transitionToPathfinding;
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
