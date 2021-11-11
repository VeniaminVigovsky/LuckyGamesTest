using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]
    private EnemyData _enemyData;

    private Enemy _enemy;

    private Rigidbody _rb;

    private AStar _pathfinding;   

    private float _speed;

    private bool _canFly;

    private void Awake()
    {
        NodeGrid grid = FindObjectOfType<NodeGrid>();

        _enemy = GetComponent<Enemy>();
        _rb = GetComponent<Rigidbody>();
        _pathfinding = new AStar(grid);
        _speed = _enemyData.MovementSpeed;
        _canFly = _enemyData.CanFly;
    }

    public void MoveTo(Vector3 position)
    {
        if (position == null) return;

        List<Node> nodes = _pathfinding.GetNodePath(_enemy.transform.position, position, _canFly);

        if (nodes == null) return;

        StartCoroutine(MoveByNodes(nodes));
    }

    public void EndMove()
    {
        StopAllCoroutines();
    }


    private IEnumerator MoveByNodes(List<Node> nodes)
    {
        foreach (var node in nodes)
        {
            Vector3 endPos = new Vector3(node.WorldPosition.x, _enemy.transform.position.y, node.WorldPosition.z);
            _enemy.transform.LookAt(endPos);
            while (Vector3.Distance(_enemy.transform.position, endPos) > 1f)
            {
                _rb.velocity = _enemy.transform.forward * _speed * Time.deltaTime;
                _rb.angularVelocity = Vector3.zero;
                yield return null;
            }
        }
    }
}
