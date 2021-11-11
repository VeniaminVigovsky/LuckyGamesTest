using System.Collections.Generic;
using UnityEngine;

public class RegularShootBehavior : IShootBehavior
{
    private Transform _spawnPoint;

    private Projectile _projectilePrefab;

    private List<GameObject> _projectilePool;

    private float _shootForce;

    private int _damage;

    public RegularShootBehavior(Transform spawnPoint,int damage, float shootForce, Projectile projectilePrefab, int poolSize)
    {
        _spawnPoint = spawnPoint;
        _damage = damage;
        _shootForce = shootForce;
        _projectilePrefab = projectilePrefab;
        _projectilePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject p = GameObject.Instantiate(_projectilePrefab.gameObject, _spawnPoint);

            _projectilePool.Add(p);
            p.SetActive(false);
            p.GetComponent<Projectile>().SetDamage(_damage);
        }
    }

    public void Shoot(Transform target)
    {        
        _spawnPoint.LookAt(target);
        GameObject p = GetFromPool();
        Rigidbody rb = p.GetComponent<Rigidbody>();
        p.transform.parent = null;
        p.transform.position = _spawnPoint.position;
        p.transform.rotation = _spawnPoint.rotation;
        p.SetActive(true);
        rb.AddForce(_spawnPoint.forward * _shootForce * Time.deltaTime, ForceMode.Impulse);
    }

    private GameObject GetFromPool()
    {
        foreach (var p in _projectilePool)
        {
            if (!p.activeInHierarchy)
            {
                return p;
            }
        }

        GameObject newP = GameObject.Instantiate(_projectilePrefab.gameObject, _spawnPoint.transform);
        _projectilePool.Add(newP);
        newP.SetActive(false);
        newP.GetComponent<Projectile>().SetDamage(_damage);
        return newP;
    }
    
}
