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
            //süre azalmaya baþlar, label'e yazýlýr.
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                //süre biterse gameover ekraný açýlýr.
                playerTom.checkJerry = false;
                gameOver = true;
                gameOverPanel.SetActive(true);
                currentTime = 0;
                
            }
           
        }

        botCount = GameObject.FindGameObjectsWithTag("Jerry");
        if (botCount.Length == 0)
        {
            //hiç "Jerry" tag'lý bot kalmazsa bir sonraki level'e geçilir, son bölüm geçilirse ana menüye dönülür.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(0);
            }
        }

    }

}
