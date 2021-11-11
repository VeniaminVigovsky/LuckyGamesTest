using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Entity
{
    [SerializeField]
    private EnemyData _enemyData;

    private WallDetection _wallDetection;

    public static Action OnEnemySpawned;

    public EnemyData EnemyData
    {
        get => _enemyData;
    }

    public override void Awake()
    {
        base.Awake();
        _entityData = _enemyData;
        _health = _entityData.MaxHealth;        

        Player player = FindObjectOfType<Player>();
        Pathfinder pathfinder = GetComponent<Pathfinder>();
        
        _wallDetection = GetComponent<WallDetection>();

        var waitState = new WaitTimeState(3);
        var idleState = new EnemyIdleState(_rb, _enemyData);
        var moveState = new MoveByVelocityState(_rb, _entityData);
        var moveByPathfindingState = new MoveByPathfindingState(this, pathfinder, player, _enemyData);
        var attackState = new AttackState(this, _rb, _weaponManager, _targetDetector, _entityData);
        var deathState = new EnemyDeathState(this);

        _stateMachine.AddTransition(waitState, moveByPathfindingState, () => waitState.TimesUp);

        _stateMachine.AddTransition(idleState, moveState, () => idleState.TimesUp && !idleState.TransitionToPathFinding);
        _stateMachine.AddTransition(idleState, moveByPathfindingState, () => idleState.TimesUp && idleState.TransitionToPathFinding);
        _stateMachine.AddTransition(idleState, attackState, () => _targetDetector.Target != null);
        

        _stateMachine.AddTransition(moveState, idleState, ()=> moveState.TimesUp() || (_wallDetection.HitWall && Vector3.Distance(transform.position, moveState.StartPosition) > 1f));       
        _stateMachine.AddTransition(moveState, attackState, () => _targetDetector.Target != null);

        _stateMachine.AddTransition(moveByPathfindingState, idleState, () => moveByPathfindingState.Finished || _wallDetection.HitWall);
        _stateMachine.AddTransition(moveByPathfindingState, attackState,() => _targetDetector.Target != null);

        _stateMachine.AddTransition(attackState, moveByPathfindingState, () => _targetDetector.Target == null);



        _stateMachine.AddAnyTransition(deathState,IsDead);

        _stateMachine.SetState(waitState);

        OnEnemySpawned?.Invoke();
    }





}
