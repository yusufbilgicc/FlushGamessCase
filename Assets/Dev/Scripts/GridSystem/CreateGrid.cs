using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public int x;
    public int y;


    [SerializeField] private float _downVal;
    [SerializeField] private float _sideVal;

    private void Start()
    {
        
        Invoke(nameof(OnCreateGrid),0.1f);
    }

    
    private void OnCreateGrid()
    {
        float yVal = 0;
        for (int i = 0; i < y; i++)
        {
            float xVal = 0;

            for (int j = 0; j < x; j++)
            {
                GridFactory.On_CreateGrid(0, new Vector3(transform.position.x + xVal, 0, transform.position.z + yVal),
                    Quaternion.identity, transform);
                xVal += _sideVal;
            }

            yVal += _downVal;
        }
    }
}