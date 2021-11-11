using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectileGraphics;

    [SerializeField]
    private ParticleSystem _particleSystem;

    private Rigidbody _rb;

    private int _damage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnEnable()
    {
        _projectileGraphics.SetActive(true);        
    }
    private void OnDisable()
    {
        _particleSystem.Stop();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        Entity entity = other.gameObject.GetComponent<Entity>();
        
        if (entity != null)
        {
            entity.ReceiveDamage(_damage);
        }

        StartCoroutine(BurstAndDisable());
    }

    private IEnumerator BurstAndDisable()
    {
        _projectileGraphics.SetActive(false);
        _particleSystem.Play();
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

}
