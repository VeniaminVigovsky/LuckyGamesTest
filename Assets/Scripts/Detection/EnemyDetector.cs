using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour, ITargetDetector
{
    public Transform Target { get; private set; }

    private Player _player;

    private List<Enemy> _targets = new List<Enemy>();

    [SerializeField]
    private GameObject _targetImagePref;

    private GameObject _targetImage;

    private void Awake()
    {
        if (_targetImagePref == null) return;
        _targetImage = Instantiate(_targetImagePref, transform);
        _targetImage.SetActive(false);

        _player = GetComponentInParent<Player>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy != null && !_targets.Contains(enemy))
        {
            _targets.Add(enemy);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null && _targets.Contains(enemy))
        {
            _targets.Remove(enemy);            
        }

    }

    private void Update()
    {
        UpdateClosestTarget();
        UpdateImage();
    }

    private void UpdateClosestTarget()
    {
        float minDist = 100.0f;

        Transform closestTarget = null;

        foreach (var target in _targets)
        {
            if (!target.gameObject.activeInHierarchy)
            {
                continue;
            }

            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist < minDist)
            {
                minDist = dist;

                closestTarget = target.transform;
            }
        }

        Target = closestTarget;
    }

    private void UpdateImage()
    {
        if (_targetImage == null) return;

        if (Target != null && !_player.InputPressed)
        {
            _targetImage.transform.position = new Vector3 (Target.position.x, 0.002f, Target.position.z);
            _targetImage.SetActive(true);
        }

        else
        {
            _targetImage.SetActive(false);
        }
    }


}
