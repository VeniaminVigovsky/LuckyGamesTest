using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;

    [SerializeField]
    private NodeGrid _grid;

    private void OnEnable()
    {
        GameplayManager.OnGameStarted += SpawnEnemies;
    }
    private void OnDisable()
    {
        GameplayManager.OnGameStarted -= SpawnEnemies;
    }

    private void SpawnEnemies()
    {
        if (_enemyPrefabs == null || _grid == null) return;

        List<Node> _openNodes = new List<Node>();

        int minY = _grid.GridSizeY / 3;
        int maxX = _grid.GridSizeX;

        Node[,] grid = _grid.Grid;

        for (int x = 0; x < maxX; x++)
        {
            for (int y = minY; y < _grid.GridSizeY; y++)
            {
                if (!grid[x, y].IsWalkable(false)) continue;

                _openNodes.Add(grid[x, y]);
            }
        }

        foreach (var enemy  in _enemyPrefabs)
        {
            int r = Random.Range(0, _openNodes.Count);
            Enemy e = enemy.GetComponent<Enemy>();
            Vector3 nodePos = _openNodes[r].WorldPosition;
            float spawnY = e.EnemyData.CanFly ? 3.14f : 1.0f;
            Vector3 spawnPos = new Vector3(nodePos.x, spawnY, nodePos.z);
            GameObject g = Instantiate(enemy, spawnPos, Quaternion.identity);
            g.transform.Rotate(Vector3.up, 180);

            _openNodes.RemoveAt(r);
        }
    }


}
