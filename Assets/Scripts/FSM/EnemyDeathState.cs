using UnityEngine;
using System;
public class EnemyDeathState : IState
{
    private Enemy _enemy;

    public static Action<Vector3> OnEnemyDied;

    public EnemyDeathState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void OnEnter()
    {
        OnEnemyDied?.Invoke(_enemy.gameObject.transform.position);
        _enemy.gameObject.SetActive(false);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
