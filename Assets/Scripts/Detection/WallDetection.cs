using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask _stoppingLayer;

    public bool HitWall { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _stoppingLayer) != 0)
        {            
            HitWall = true;
        }

    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _stoppingLayer) != 0)
        {
            HitWall = false;
        }

    }
}
