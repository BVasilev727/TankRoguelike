using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField]
    Slider bar;

    public void SetState(int current, int max)
    {
        bar.maxValue = max;
        bar.value = current;

    }
}