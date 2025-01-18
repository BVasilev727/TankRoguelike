using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleTImer : MonoBehaviour
{
    public float targetTime = 5f * 60f;
    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    GameObject runWonPanel;
    [SerializeField]
    GameObject runLostPanel;

    private PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -=Time.deltaTime;
        if (targetTime <= 0)
        {
            runWonPanel.SetActive(true);
            pauseManager.PauseGame();
        }
        else
        {
            int minutes = Mathf.FloorToInt(targetTime / 60);
            int seconds = Mathf.FloorToInt(targetTime % 60);
            timeText.text = minutes + ":" + seconds;
        }
        if(runLostPanel.active == true)
        {
            pauseManager.PauseGame();
        }
        
    }
    public int returnMinutes()
    {
        return (int)Mathf.FloorToInt(targetTime / 60);
    }
}
