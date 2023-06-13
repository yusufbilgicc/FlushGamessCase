using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleGemFrame : AGemFrame
{
    public static event Action UpdatePurpleGemFrame;

    private void OnEnable()
    {
        UpdatePurpleGemFrame += UpdateCollectCount;
    }

    private void OnDisable()
    {
        UpdatePurpleGemFrame -= UpdateCollectCount;

    }

    public static void OnUpdateGreenGemFrame()
    {
        UpdatePurpleGemFrame?.Invoke();
    }
}
