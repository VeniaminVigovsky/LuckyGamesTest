using UnityEngine;
public class MoveByVelocityState : IState
{
    private Rigidbody _rb;

    private float _speed;

    private float _startTime;

    private float _duration, _minDur = 0.2f, _maxDur = 1f;

    private Vector3 _startPosition;

    public Vector3 StartPosition
    {
        get => _startPosition;
    }

    public bool TimesUp()
    {
        return _startTime + _duration < Time.time; 
    }

    public MoveByVelocityState(Rigidbody rb, EntityData entityData)
    {
        _rb = rb;
        _speed = entityData.MovementSpeed;
    }

    public void OnEnter()
    {
        SetRandomVelocity();
        _startPosition = _rb.gameObject.transform.position;
        _startTime = Time.time;
        _duration = Random.Range(_minDur, _maxDur);
    }

    public void OnExit()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void Tick()
    {
        
    }

    private void SetRandomVelocity()
    {
        if (_rb == null) return;
        
        Vector2 randVector = Random.insideUnitCircle.normalized;
        _rb.transform.LookAt(new Vector3(randVector.x, _rb.transform.position.y, randVector.y));
        _rb.velocity = new Vector3(randVector.x * _speed * Time.deltaTime, 0, randVector.y * _speed * Time.deltaTime);
    }
}
