using UnityEngine;
using System;
public class DoorController : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;

    public static Action<bool> OnLevelFinished;

    private void OnEnable()
    {
        GameplayManager.OnAllEnemiesDead += OpenDoor;
    }

    private void OnDisable()
    {
        GameplayManager.OnAllEnemiesDead -= OpenDoor;
    }

    private void OpenDoor()
    {
        _door?.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLevelFinished?.Invoke(true);
        }
    }
}
