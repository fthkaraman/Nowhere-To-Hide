using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu; //settings butonuna basýnca mainmenuyu kapatmak için
    public GameObject slider; 
    public int counter = 0; //buton aç-kapa için

    public void playJerry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Jerry olarak oyuna baþla
        Score.scoreValue = 0;//oyuna baþlarken skoru sýfýrla
    }

    public void playTom()
    {
        SceneManager.LoadScene(4); //Tom olarak oyuna baþla
    }

    public void settingsButton()
    {
        //setting's butonu

        counter++;

        if (counter % 2 == 1)
        {
            mainMenu.SetActive(false);

            slider.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            slider.SetActive(false);
        }
    }
}
