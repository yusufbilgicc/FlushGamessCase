using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolFactory : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject _obj = Instantiate(pool.prefab, transform);
                _obj.SetActive(false);
                objectPool.Enqueue(_obj);
            }

            poolDictionary.Add(pool.id, objectPool);
        }
    }
}
    [Serializable]
public class Pool
{
    public int id;
    public GameObject prefab;
    public int size;
}
