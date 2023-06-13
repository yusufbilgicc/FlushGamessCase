using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenGemFrame : AGemFrame
{
    public static event Action UpdateGreenGemFrame;

    private void OnEnable()
    {
        UpdateGreenGemFrame += UpdateCollectCount;
    }

    private void OnDisable()
    {
        UpdateGreenGemFrame -= UpdateCollectCount;

    }

    public static void OnUpdateGreenGemFrame()
    {
        UpdateGreenGemFrame?.Invoke();
    }
}
