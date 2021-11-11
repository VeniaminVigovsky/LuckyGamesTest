using System.Collections.Generic;
using UnityEngine;
public class DoubleShootBehavior : IShootBehavior
{
    private Transform _spawnPoint;

    private List<Transform> _spawnPoints = new List<Transform>();

    private Projectile _projectilePrefab;

    private List<GameObject> _projectilePool;

    private float _shootForce;

    private int _damage;

    public DoubleShootBehavior(Transform spawnPoint, int damage, float shootForce, Projectile projectilePrefab, int poolSize)
    {
        _spawnPoint = spawnPoint;
        _damage = damage;
        _shootForce = shootForce;
        _projectilePrefab = projectilePrefab;
        _projectilePool = new List<GameObject>();

        Transform[] _additionalSpawnPoints = new Transform[2];

        for (int i = 0; i < _additionalSpawnPoints.Length; i++)
        {
            GameObject g = GameObject.Instantiate(_spawnPoint.gameObject, _spawnPoint.parent);
            g.transform.rotation = _spawnPoint.rotation;
            _additionalSpawnPoints[i] = g.transform;
            _additionalSpawnPoints[i].position = _spawnPoint.position + Vector3.right * Mathf.Pow(-1, i) * 0.5f;            

            _spawnPoints.Add(_additionalSpawnPoints[i]);
        }

        foreach (var sp in _spawnPoints)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject p = GameObject.Instantiate(_projectilePrefab.gameObject, sp);

                _projectilePool.Add(p);
                p.GetComponent<Projectile>().SetDamage(_damage);
                p.SetActive(false);
            }
        }
    }

    public void Shoot(Transform target)
    {
        foreach (var sp in _spawnPoints)
        {
            sp.LookAt(target);
            GameObject p = GetFromPool();
            Rigidbody rb = p.GetComponent<Rigidbody>();
            p.transform.position = _spawnPoint.position;
            p.transform.rotation = _spawnPoint.rotation;
            p.SetActive(true);
            rb.AddForce(sp.forward * _shootForce * Time.deltaTime, ForceMode.Impulse);
        }

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
        newP.GetComponent<Projectile>().SetDamage(_damage);
        newP.SetActive(false);
        return newP;
    }
}
