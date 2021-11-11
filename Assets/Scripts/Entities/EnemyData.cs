using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Entity Data/Enemy Data")]
public class EnemyData : EntityData
{
    [SerializeField]
    private float _idleDuration;

    [SerializeField]
    private float _moveDistance;

    [SerializeField]
    private bool _canFly;

    public float IdleDuration
    {
        get => _idleDuration;
    }

    public float MoveDistance
    {
        get => _moveDistance;
    }

    public bool CanFly
    {
        get => _canFly;
    }
}
