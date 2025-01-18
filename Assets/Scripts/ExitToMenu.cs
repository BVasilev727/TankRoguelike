using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
   public void BackToMenu()
    {
        Debug.Log("You wanna go back?");
        SceneManager.LoadScene("MainMenu");
    }
}
