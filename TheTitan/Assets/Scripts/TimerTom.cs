using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerTom : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 45f;
    float startingTime2 = 40f;
    float startingTime3 = 25f;

    public static bool checkTime;

    public static bool gameOver;
    public GameObject gameOverPanel;

    public GameObject[] botCount;

    [SerializeField]
    Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        checkTime = true;
        currentTime = startingTime;

        if (SceneManager.GetActiveScene().buildIndex == 5)//Tom Level 2
        {
            currentTime = startingTime2;
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)//Tom Level 3
        {
            currentTime = startingTime3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (checkTime)
        {
            //s�re azalmaya ba�lar, label'e yaz�l�r.
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                //s�re biterse gameover ekran� a��l�r.
                playerTom.checkJerry = false;
                gameOver = true;
                gameOverPanel.SetActive(true);
                currentTime = 0;
                
            }
           
        }

        botCount = GameObject.FindGameObjectsWithTag("Jerry");
        if (botCount.Length == 0)
        {
            //hi� "Jerry" tag'l� bot kalmazsa bir sonraki level'e ge�ilir, son b�l�m ge�ilirse ana men�ye d�n�l�r.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

}
