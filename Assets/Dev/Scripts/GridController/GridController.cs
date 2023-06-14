using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridController : MonoBehaviour
{
    public Transform gemPos;

    public float spawnRate;


    private void Start()
    {
        CreateGem();
    }

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