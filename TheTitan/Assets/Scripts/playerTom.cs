using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTom : MonoBehaviour
{
    public Run playerScript;
    Animator anim;
    public static bool checkJerry;

    public AudioSource playSound;

    // Start is called before the first frame update
    void Start()
    {
        checkJerry = true;
        gameObject.tag = "Player";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkJerry && Input.touches.Length > 0)
        {
            
            //Raycast sistemi ile ýþýn göndererek haraket saðlanýr.
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(touchRay, out hit))
                {
                    Vector3 newpos = hit.point;
                    playerScript.targetPos = newpos;
                }
            }
            //koþma animasyonu çaðrýlýr.
            anim.SetBool("isRunning", true);
        }
        else
        {
            //anim.SetBool("isRunning", false);
        }

    }
    //Nesnelerin birbirine dokunduðunda oluþacak aksiyon.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jerry")
        {
            playSound.Play();
            Flee fleeScript = other.GetComponent<Flee>();
            fleeScript.canMove = false;
            //yakalanan Jerry'nin tag'ý "Caught" olur Tom hedef deðiþtirir.
            fleeScript.gameObject.tag = "Caught";
            Score.scoreValue += 100;
        }
        
    }
}

