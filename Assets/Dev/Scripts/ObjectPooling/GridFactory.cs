using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFactory : ObjectPoolFactory
{
    public static event Action<int, Vector3, Quaternion,Transform> OnCreateGrid;

    private void OnEnable()
    {
        OnCreateGrid += GetCreateGrid;
    }

    private void OnDisable()
    {
        OnCreateGrid -= GetCreateGrid;
    }


    public void GetCreateGrid(int _id, Vector3 _pos, Quaternion _rot, Transform _parent)
    {
        GridController gridSpawn = poolDictionary[_id].Dequeue().GetComponent<GridController>();
        gridSpawn.gameObject.SetActive(true);
        gridSpawn.transform.SetParent(_parent);
        gridSpawn.transform.position = _pos;
        gridSpawn.transform.rotation = _rot;
        gridSpawn.CreateGem();

        poolDictionary[_id].Enqueue(gridSpawn.gameObject);
    }

    public static void On_CreateGrid(int arg1, Vector3 arg2, Quaternion arg3,Transform arg4)
    {
        OnCreateGrid?.Invoke(arg1, arg2, arg3,arg4);
    }
}