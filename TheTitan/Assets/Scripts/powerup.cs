using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    //hýzlandýrma katsayýsý
    public float multiplier = 1.5f;

    public float duration = 4f;

    public AudioSource playSound;

    //patlama efekti için
    public GameObject pickupEffect;

    public float rotateSpeed;

    void Start()
    {
        rotateSpeed = 0.2f;
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playSound.Play();
            //hýz artýþýnýn baþlatýlmasý
            StartCoroutine(Pickup(other));
   
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Debug.Log("Power");

        //patlama efektin yerini tanýmlamak için
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //karakterimizin hýzýný artýrmak için
        Run playerSpeed = player.GetComponent<Run>();
        playerSpeed.speed *= multiplier;

        //gücü aldýktan sonra objenin kapatýlmasý.
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        //hýz 4 saniye sonra eski haline döner
        playerSpeed.speed /= multiplier;

        //obje tamamen yok edilir.
        Destroy(gameObject);
    }
}
