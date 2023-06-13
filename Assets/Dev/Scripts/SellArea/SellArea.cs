using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour,ITrigger
{

    public Transform gemGoPos;
    public Collider myCol;
    
    public void ITrig()
    {
        SellProcess();
    }

    public void SellProcess()
    {
        PlayerCollectList.On_SellGem(gemGoPos);
        myCol.enabled = false;
        Invoke(nameof(CollOpen),0.1f);
    }

    public void CollOpen()
    {
        myCol.enabled = true;
    }
}
