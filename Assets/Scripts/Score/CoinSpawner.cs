using System.Collections.Generic;
using UnityEngine;
public class CoinSpawner : MonoBehaviour
{    
    [SerializeField]
    private GameObject _coinPrefab;

    [SerializeField]
    private Player _player;

    private bool _collectCoins;

    private List<GameObject> _coins = new List<GameObject>();

    private float _collectSpeed = 10f;

    private void OnEnable()
    {
        EnemyDeathState.OnEnemyDied += SpawnCoin;
        GameplayManager.OnAllEnemiesDead += ToggleCollect;
        _collectCoins = false;
    }

    private void OnDisable()
    {
        EnemyDeathState.OnEnemyDied -= SpawnCoin;
        GameplayManager.OnAllEnemiesDead -= ToggleCollect;
        _collectCoins = false;
    }
    private void SpawnCoin(Vector3 position)
    {
        Vector3 pos = new Vector3(position.x, 1f, position.z);

        GameObject c = Instantiate(_coinPrefab, pos, Quaternion.identity);
        _coins.Add(c);        
    }

    private void Update()
    {
        if (_collectCoins)
        {
            foreach (var coin in _coins)
            {
                coin.transform.position = Vector3.Lerp(coin.transform.position, _player.transform.position, _collectSpeed * Time.deltaTime);
            }
        }
    }

    private void ToggleCollect()
    {
        _collectCoins = true;
    }
}
