using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputs : MonoBehaviour
{
    public Run playerScript;
    public bool canMove;
    Animator anim;

    public static bool gameOver;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        gameObject.tag = "Player";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (canMove && Input.touches.Length > 0)
        {
            anim.SetBool("isRunning", true);

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Raycast sistemi ile ýþýn göndererek haraket saðlanýr.
                Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(touchRay, out hit))
                {
                    Vector3 newpos = hit.point;
                    playerScript.targetPos = newpos;
                }
            }
        }
        //yakalandýysak oyun biter.
        else if(gameObject.tag == "Caught")
        {
            gameOver = true;
            gameOverPanel.SetActive(true);

            anim.SetBool("isRunning", false);
      
        }      
    }
}
