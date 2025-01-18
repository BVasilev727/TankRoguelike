using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    int experience = 0;
    int level = 1;
    [SerializeField]
    XpBar xpBar;

    [SerializeField]
    TMP_Text levelText;

    [SerializeField]
    UpgradePanelManager upgradePanel;
    
    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }

    private void Start()
    {
        xpBar.SetState(experience,TO_LEVEL_UP);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        xpBar.SetState(experience, TO_LEVEL_UP);
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if(experience>=TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        upgradePanel.OpenPanel();
        experience -= (TO_LEVEL_UP);
        level++;
        levelText.text = "Level: " + level;
    }
}
