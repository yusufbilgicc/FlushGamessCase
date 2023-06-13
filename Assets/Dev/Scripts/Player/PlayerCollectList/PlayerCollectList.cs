using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerCollectList : MonoBehaviour
{
    public List<AGem> gemList = new List<AGem>();
    public float yVal;

    public static event Action<AGem> OnAddList;
    public static event Action<AGem> OnRemoveList;
    public static event Action<AGem> OnPlaceGem;
    public static event Action<Transform> OnSellGem;

    private void OnEnable()
    {
        OnAddList += AddList;
        OnRemoveList += RemoveList;
        OnPlaceGem += GemPlacement;
        OnSellGem += SellGem;
    }

    private void OnDisable()
    {
        OnAddList -= AddList;
        OnRemoveList -= RemoveList;
        OnPlaceGem -= GemPlacement;
        OnSellGem -= SellGem;
    }

    public void AddList(AGem gem)
    {
        gemList.Add(gem);
    }

    public void RemoveList(AGem gem)
    {
        gemList.Remove(gem);
    }

    public void GemPlacement(AGem gem)
    {
        gem.transform.SetParent(this.transform);
        gem.transform.DOLocalJump(new Vector3(0, gemList.Count * .3f, 0), 1, 1, 0.5f);
    }

    public void SellGem(Transform pos)
    {
        if (gemList.Count ==0)
        {
            return;
        }
        AGem gem = gemList[^1];
        gem.transform.SetParent(null);
        On_RemoveList(gem);
        gem.transform.DOJump(pos.position, 1, 1, .5f).OnComplete(() => { gem.gameObject.SetActive(false); });
        // giveMoney
        CurrencyController.OnAddMoney(gem.price);
    }

    public static void On_AddList(AGem obj)
    {
        OnAddList?.Invoke(obj);
    }

    public static void On_RemoveList(AGem obj)
    {
        OnRemoveList?.Invoke(obj);
    }

    public static void On_PlaceGem(AGem obj)
    {
        OnPlaceGem?.Invoke(obj);
    }

    public static void On_SellGem(Transform pos)
    {
        OnSellGem?.Invoke(pos);
    }
}