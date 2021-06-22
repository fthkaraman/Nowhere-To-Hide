using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;
    public AudioSource playSound;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        // y ekseninde yukarda tanýmlanan hýzla döner.
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        //player coin'e dokunursa
        if (other.CompareTag("Player"))
        {
            playSound.Play();
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        //coin yok olur, skor artar

        Destroy(gameObject);

        Score.scoreValue += 100;
    }
}
