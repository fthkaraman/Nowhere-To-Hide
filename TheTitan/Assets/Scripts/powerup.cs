using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    //h�zland�rma katsay�s�
    public float multiplier = 1.5f;

    public float duration = 4f;

    public AudioSource playSound;

    //patlama efekti i�in
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
            //h�z art���n�n ba�lat�lmas�
            StartCoroutine(Pickup(other));
   
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Debug.Log("Power");

        //patlama efektin yerini tan�mlamak i�in
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //karakterimizin h�z�n� art�rmak i�in
        Run playerSpeed = player.GetComponent<Run>();
        playerSpeed.speed *= multiplier;

        //g�c� ald�ktan sonra objenin kapat�lmas�.
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        //h�z 4 saniye sonra eski haline d�ner
        playerSpeed.speed /= multiplier;

        //obje tamamen yok edilir.
        Destroy(gameObject);
    }
}
