using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField]
    Slider bar;

    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if(state < 0f)
        {
            state = 0f;
        }
        bar.value = state;

    }
}
