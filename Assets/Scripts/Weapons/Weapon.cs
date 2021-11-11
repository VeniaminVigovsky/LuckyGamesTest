using UnityEngine;

public class Weapon : IWeapon
{
    private IShootBehavior _shootBehavior;

    public Weapon(IShootBehavior shootBehavior)
    {
        _shootBehavior = shootBehavior;        
    }

    public void Shoot(Transform target)
    {
        _shootBehavior?.Shoot(target);
    }

}
