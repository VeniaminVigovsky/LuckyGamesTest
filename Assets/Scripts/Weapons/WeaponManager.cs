using UnityEngine;

[RequireComponent(typeof(WeaponFactory))]
public class WeaponManager : MonoBehaviour, IWeaponManager
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
        if (Stats.CoinCount > 2)
        {
            _currentWeapon = _factory.GetDoubleShootWeapon(_spawnPoint, _entityData.Damage);
        }
        else
        {
            _currentWeapon = _factory.GetRegularWeapon(_spawnPoint, _entityData.Damage);
        }        
    }

    public IWeapon CurrentWeapon
    {
        get => _currentWeapon;
    }

}
