using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour,ITrigger
{

    public Transform gemGoPos;
    
    public void ITrig()
    {
        SellProcess();
    }

    public void SellProcess()
    {
        PlayerCollectList.On_SellGem(gemGoPos);
    }
}
