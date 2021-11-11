using UnityEngine;
using System;
public class GameplayManager : MonoBehaviour
{
    public static Action OnAllEnemiesDead;

    private static float _timeStarted;

    public static Action OnGameStarted;

    public static float ElapsedTime
    {
        get => Time.time - _timeStarted;
    }

    private int _enemyCount;

    private void Awake()
    {
        EnemyDeathState.OnEnemyDied += DecreaseEnemyCount;
        Enemy.OnEnemySpawned += IncreaseEnemyCount;
        PlayerDeathState.OnPlayerDied += ResetCoins;
    }

    private void Start()
    {
        OnGameStarted?.Invoke();
        _timeStarted = Time.time;
    }

    public void IncreaseEnemyCount()
    {
        _enemyCount++;
    }

    public void DecreaseEnemyCount(Vector3 pos)
    {
        _enemyCount--;
        if (_enemyCount <= 0)
        {
            OnAllEnemiesDead?.Invoke();
        }
    }

    private void OnDisable()
    {
        EnemyDeathState.OnEnemyDied -= DecreaseEnemyCount;
        Enemy.OnEnemySpawned -= IncreaseEnemyCount;
    }

    private void ResetCoins(bool win)
    {
        if (!win)
        {
            Stats.CoinCount = 0;
        }
    }
}
