using UnityEngine;

public class PlayerDetector : MonoBehaviour, ITargetDetector
{    
    public Transform Target { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Target = player.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            Target = null;
        }
    }

}
