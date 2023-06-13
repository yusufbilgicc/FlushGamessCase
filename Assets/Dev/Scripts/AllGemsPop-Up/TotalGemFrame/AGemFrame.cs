using System;
using System.Collections;
using System.Collections.Generic;
using Dev.Scripts.AllGemsPop_Up.GemFrameData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AGemFrame : MonoBehaviour
{
    public FrameData frameData;

    public int totalCount;
    public string totalCountKey;
    public TMP_Text gemTypeText;
    public TMP_Text gemCountText;
    public Image frameIcon;


    public void Save()
    {
        PlayerPrefs.SetInt(totalCountKey, totalCount);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(totalCountKey))
        {
            totalCount = PlayerPrefs.GetInt(totalCountKey);
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Start()
    {
        totalCountKey = frameData.gemType + "Key";
        Load();
        StartSettings();
    }

    public void StartSettings()
    {
        SetString();
        SetCollectCount();
        SetIcon();
    }

    public void SetString()
    {
        gemTypeText.text = "Gem Type : " + frameData.gemType;
    }

    public void SetCollectCount()
    {
        gemCountText.text = "Collect Count : " + totalCount.ToString("0");
    }

    public void SetIcon()
    {
        frameIcon.sprite = frameData.frameIcon;
    }

    public void UpdateCollectCount()
    {
        totalCount += 1;
        SetCollectCount();
    }
}