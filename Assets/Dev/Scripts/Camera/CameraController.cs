using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void Start()
    {
       
        offset = this.transform.position - player.transform.position;
    }

    private void Update()
    {
        Vector3 desiredPos = player.position + offset;
        transform.position = Vector3.Lerp(this.transform.position,desiredPos,Time.deltaTime * smoothSpeed);
        
    }
}
