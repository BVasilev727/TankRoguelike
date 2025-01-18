using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timerDuration = 5f * 60f;

    private float timer;
    [SerializeField]
    TextMeshProUGUI timerText;

    void Start()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        timer = timerDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}",minutes,seconds);

        timerText.text = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer = -Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else
        {

        }
    }
}
