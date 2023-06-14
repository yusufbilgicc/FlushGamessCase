using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

[ExecuteInEditMode]
public class LevelDesigner : MonoBehaviour
{
    [Range(-20, 20)] public float posX = 0;
    [Range(-20, 20)] public float posZ = 0;
    
    public int x;
    public int y;

    public GameObject curPrefab;
    public List<GameObject> createdList = new List<GameObject>();


    private void Update()
    {
        if (createdList.Count != 0)
        {
            createdList[^1].transform.position = new Vector3(posX, 0, posZ);
        }
    }

    public void BuildObject()
    {
        CreateGrid s = Instantiate(curPrefab, new Vector3(posX, 0, posZ), Quaternion.identity)
            .GetComponent<CreateGrid>();
        createdList.Add(s.gameObject);
        s.CreateOnEditor(x, y);
    }

    public void DeleteLastObject()
    {
        DestroyImmediate(createdList[^1]);
        createdList.Remove(createdList[^1]);
    }
}