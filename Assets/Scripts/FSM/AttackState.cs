using UnityEngine;
public class AttackState : IState
{
    private Entity _entity;

    private Rigidbody _rb;

    private IWeapon _currentWeapon;

    private IWeaponManager _weaponManager;

    private ITargetDetector _targetDetector;

    private float _fireRate;

    private float _lastShotTime = -100;

    public AttackState(Entity entity, Rigidbody rb, IWeaponManager weaponManager, ITargetDetector targetDetector, EntityData entityData)
    {
        _entity = entity;
        _rb = rb;
        _weaponManager = weaponManager;
        _targetDetector = targetDetector;
        _fireRate = entityData.FireRate;
    }

    

    public void OnEnter()
    {
        if (_weaponManager == null) return;
        _currentWeapon = _weaponManager.CurrentWeapon;
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        Transform target = _targetDetector.Target;
        if (target != null)
        {
            _entity.transform.LookAt(new Vector3(target.position.x, _entity.transform.position.y, target.position.z));

            if (_lastShotTime + 60 / _fireRate < Time.time)
            {
                _currentWeapon?.Shoot(target);
                _lastShotTime = Time.time;
            }

        }
    }
}
