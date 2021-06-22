using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu; //settings butonuna bas�nca mainmenuyu kapatmak i�in
    public GameObject slider; 
    public int counter = 0; //buton a�-kapa i�in

    public void playJerry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Jerry olarak oyuna ba�la
        Score.scoreValue = 0;//oyuna ba�larken skoru s�f�rla
    }

    public void playTom()
    {
        SceneManager.LoadScene(4); //Tom olarak oyuna ba�la
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
