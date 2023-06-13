using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public float range;
    public PlayerMovement playerMove;

    private void LateUpdate()
    {
        // if (playerMove.isMove)
        {
            CheckTrig();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere (transform.position , range);
    }

    public void CheckTrig()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out ITrigger ıtrigger))
            {
                ıtrigger.ITrig();
            }
        }
    }
}