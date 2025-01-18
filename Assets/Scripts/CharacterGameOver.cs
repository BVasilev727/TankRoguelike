using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField]
    GameObject gun;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Lol u died");
        GetComponent<PlayerMovement>().enabled = false;
        gun.GetComponent<PlayerGun>().enabled = false;  
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }
}

