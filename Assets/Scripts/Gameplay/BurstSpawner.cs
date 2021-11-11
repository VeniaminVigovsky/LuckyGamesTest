using UnityEngine;
public class BurstSpawner : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particles;

    private void OnEnable()
    {
        EnemyDeathState.OnEnemyDied += BurstParticles;
    }

    private void OnDisable()
    {
        EnemyDeathState.OnEnemyDied -= BurstParticles;
    }

    private void BurstParticles(Vector3 position)
    {
        if (_particles == null) return;
        _particles.Stop();
        _particles.gameObject.transform.position = position;
        _particles.Play();
    }

}
