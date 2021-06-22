using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform theTarget;
    public GameObject thePlayer;

    public AudioSource playSound;

    public GameObject teleportEffect;

    void OnTriggerEnter(Collider other)
    {     
        
        if (other.gameObject.tag == "Player")
        {
            // efekt ortaya çýkar, hedefe ýþýnlanýlýr.
            playSound.Play();
            Instantiate(teleportEffect, transform.position, transform.rotation);
            thePlayer.transform.position = theTarget.transform.position;
        }      
    }

}
