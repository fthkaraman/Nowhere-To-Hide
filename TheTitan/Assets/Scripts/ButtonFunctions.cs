using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject gameOverPanel;
    public int counter = 0;

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.scoreValue = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMenu()
    {
        counter++;

        if (counter % 2 == 1)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
        
    }
}
