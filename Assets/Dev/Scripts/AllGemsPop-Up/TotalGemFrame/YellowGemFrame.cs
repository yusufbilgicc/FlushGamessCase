using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGemFrame : AGemFrame
{
    public static event Action UpdateYellowGemFrame;

    private void OnEnable()
    {
        UpdateYellowGemFrame += UpdateCollectCount;
    }

    private void OnDisable()
    {
        UpdateYellowGemFrame -= UpdateCollectCount;

    }

    public static void OnUpdateGreenGemFrame()
    {
        UpdateYellowGemFrame?.Invoke();
    }
}
