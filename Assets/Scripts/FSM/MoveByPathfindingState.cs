using UnityEngine;
public class MoveByPathfindingState : IState
{
    private Enemy _enemy;

    private Pathfinder _pathfinder;

    private Player _player;

    private Vector3 _startPosition;

    private float _maxDistance;

    public bool Finished
    {
        get => Vector3.Distance(_startPosition, _enemy.transform.position) >= _maxDistance;
    }

    public MoveByPathfindingState(Enemy enemy, Pathfinder pathfinder, Player player, EnemyData enemyData)
    {
        _enemy = enemy;
        _pathfinder = pathfinder;
        _player = player;
        _maxDistance = enemyData.MoveDistance;
    }

    public void OnEnter()
    {
        if (!_player.gameObject.activeInHierarchy)
        {
            _startPosition = _enemy.transform.position + Vector3.one * _maxDistance * 2;
        }
        else
        {
            _startPosition = _enemy.transform.position;
            _pathfinder.MoveTo(_player.transform.position);
        }        
    }

    public void OnExit()
    {
        _pathfinder.EndMove();
    }

    public void Tick()
    {
        
    }
}
