using UnityEngine;

[RequireComponent(typeof(WeaponFactory))]
public class WalkingEnemyWeaponManager : MonoBehaviour, IWeaponManager
{
    private WeaponFactory _factory;

    [SerializeField]
    private EntityData _entityData;

    [SerializeField]
    private Transform _spawnPoint;

    private IWeapon _currentWeapon;

    private void Awake()
    {
        _factory = GetComponent<WeaponFactory>();
        _currentWeapon = _factory.GetTripleShootWeapon(_spawnPoint, _entityData.Damage);
    }

    public IWeapon CurrentWeapon
    {
        get => _currentWeapon;
    }
}
