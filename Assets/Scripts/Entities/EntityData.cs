using UnityEngine;
public abstract class EntityData : ScriptableObject
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _fireRate = 5;

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private int _maxHealth = 10;

    public float MovementSpeed
    {
        get => _movementSpeed;
    }

    public float FireRate
    {
        get => _fireRate;
    }

    public int Damage
    {
        get => _damage;
    }

    public int MaxHealth
    {
        get => _maxHealth;
    }

}
