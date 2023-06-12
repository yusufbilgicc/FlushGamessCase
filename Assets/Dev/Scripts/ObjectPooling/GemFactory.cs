using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemFactory : ObjectPoolFactory
{
  public static event Action<int, GridController, Quaternion> OnCreateGem;

  // private void Start()
  // {
  //   GeneralController.Instance.gemFactory = this;
  // }

  private void OnEnable()
  {
    OnCreateGem += GetCreateGem;
  }

  private void OnDisable()
  {
    OnCreateGem -= GetCreateGem;

  }

  public void GetCreateGem(int _id,GridController _grid,Quaternion _rot)
  {
    AGem gemSpawn = poolDictionary[_id].Dequeue().GetComponent<AGem>();
    gemSpawn.gameObject.SetActive(true);
    gemSpawn.transform.position = _grid.gemPos.transform.position;
    gemSpawn.transform.rotation = _rot;
    poolDictionary[_id].Enqueue(gemSpawn.gameObject);
    gemSpawn.myGrid = _grid;
    gemSpawn.StartGrow();
  }
  
  
  public static void On_CreateGem(int arg1, GridController arg2, Quaternion arg3)
  {
    OnCreateGem?.Invoke(arg1, arg2, arg3);
  }
}
