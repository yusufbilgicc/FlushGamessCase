using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
   public float totalMoney;
   public string totalMoneyKey;
   public TMP_Text totalMoneyText;
   public static event Action<float> AddMoneyEvent;
   public static event Action<float> RemoveMoneyEvent;

   private void Start()
   {
      Load();
      SetMoneyText();
   }
   
   public void Save()
   {
      PlayerPrefs.SetFloat(totalMoneyKey, totalMoney);
   }

   public void Load()
   {
      if (PlayerPrefs.HasKey(totalMoneyKey))
      {
         totalMoney = PlayerPrefs.GetFloat(totalMoneyKey);
      }
   }

   private void OnEnable()
   {
      AddMoneyEvent += AddMoney;
      RemoveMoneyEvent += RemoveMoney;
   }

   private void OnDisable()
   {
      AddMoneyEvent -= AddMoney;
      RemoveMoneyEvent -= RemoveMoney;
   }

   private void OnApplicationQuit()
   {
      Save();
   }

   public static void OnAddMoney(float obj)
   {
      AddMoneyEvent?.Invoke(obj);
   }

   public static void OnRemoveMoney(float obj)
   {
      RemoveMoneyEvent?.Invoke(obj);
   }


   public void SetMoneyText()
   {
      totalMoneyText.text = totalMoney.ToString("F1");
   }

   public void AddMoney(float val)
   {
      totalMoney += val;
      SetMoneyText();
   }

   public void RemoveMoney(float val)
   {
      totalMoney -= val;
      SetMoneyText();
   }
}
