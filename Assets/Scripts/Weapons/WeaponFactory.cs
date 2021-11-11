using UnityEngine;
public class WeaponFactory : MonoBehaviour
{
    [SerializeField]
    private Projectile defaultProjectilePrefab;

    private int defaultPoolSize = 10;    

    public IWeapon GetRegularWeapon(Transform spawnPosition, int damage, float shootForce = 1000)
    {
        IShootBehavior shootBehavior = new RegularShootBehavior(spawnPosition, damage, shootForce, defaultProjectilePrefab, defaultPoolSize);
        IWeapon weapon = new Weapon(shootBehavior);
        return weapon;
    }

    public IWeapon GetTripleShootWeapon(Transform spawnPosition, int damage, float shootForce = 1000)
    {
        IShootBehavior shootBehavior = new TripleShootBehavior(spawnPosition, damage, shootForce, defaultProjectilePrefab, defaultPoolSize);
        IWeapon weapon = new Weapon(shootBehavior);
        return weapon;
    }

    public IWeapon GetDoubleShootWeapon(Transform spawnPosition, int damage, float shootForce = 1000)
    {
        IShootBehavior shootBehavior = new DoubleShootBehavior(spawnPosition, damage, shootForce, defaultProjectilePrefab, defaultPoolSize);
        IWeapon weapon = new Weapon(shootBehavior);
        return weapon;
    }
}
