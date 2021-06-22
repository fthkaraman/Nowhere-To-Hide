using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 20f;
    float startingTime2 = 25f; 
    float startingTime3 = 30f;

    public static bool checkTime;

    [SerializeField]
    Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        checkTime = true;
        currentTime = startingTime;

        if (SceneManager.GetActiveScene().buildIndex == 2)//Jerry Level 2
        {
            currentTime = startingTime2;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)//Jerry Level 3
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
                //s�re biterse yeni level'e ge�ilir, son level'de isek ana men�ye d�n�l�r.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    SceneManager.LoadScene(0);
                }
                
            }
        }
        
    }
    
}
