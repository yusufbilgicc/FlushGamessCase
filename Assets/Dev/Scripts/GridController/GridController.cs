using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Transform gemPos;

    public float spawnRate;


    public void CreateGem()
    {
        int s = Random.Range(0, 3);
            GemFactory.On_CreateGem(s,this,Quaternion.identity);
    }


    public void StartSpawnProcess()
    {
        Invoke(nameof(CreateGem), spawnRate);
    }
}