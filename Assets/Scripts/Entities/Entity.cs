using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    protected EntityData _entityData;

    protected Rigidbody _rb;

    protected StateMachine _stateMachine;

    protected int _health;

    protected bool _isDead;

    public Action<int> OnHealthChanged;

    protected IWeaponManager _weaponManager;

    protected ITargetDetector _targetDetector;
    

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _stateMachine = new StateMachine();

        _weaponManager = GetComponentInChildren<IWeaponManager>();
        _targetDetector = GetComponentInChildren<ITargetDetector>();

        
    }

    public virtual void Update() => _stateMachine.Tick();

    public virtual void ReceiveDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health);
    }

    public virtual bool IsDead()
    {
        return _health <= 0;
    }

    public int MaxHealth
    {
        get => _entityData.MaxHealth;
    }

}
