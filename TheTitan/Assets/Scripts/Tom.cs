using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Tom : MonoBehaviour
{
    GameObject[] target; //botlarý tutan array
    GameObject[] player;  //player'ý tutan array 
    GameObject[] final_array; //iki array'in birleþimi
    GameObject randomTarget;
    public AudioSource playSound;
    NavMeshAgent nav;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {      
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //oyun baþýnda Tom'un beklemesi
        StartCoroutine(waitThreeSeconds());
    }

    // Update is called once per frame
    void Update()
    {

        FindClosestEnemy();       
       
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Jerry":
                playSound.Play();
                Flee fleeScript = other.GetComponent<Flee>();
                fleeScript.canMove = false;
                fleeScript.gameObject.tag = "Caught";
                break;

            case "Player":
                playSound.Play();
                TouchInputs touchScript = other.GetComponent<TouchInputs>();
                touchScript.canMove = false;
                touchScript.gameObject.tag = "Caught";

                //yakalanýrsak süre durdurulur.
                Timer.checkTime = false;
                
                //Tom durdurulur
                nav.isStopped = true;
                anim.SetBool("isRunning", false);
                break;
        }
    }

    public GameObject FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        //Jerry taglý karakterleri array'e at
        target = GameObject.FindGameObjectsWithTag("Jerry");
        //Player taglý karakterleri array'e at
        player = GameObject.FindGameObjectsWithTag("Player");
        //bot array'ini sadece botlarýn kovalanmamasý için kendi array'imiz ile birleþtiriyoruz.
        final_array = target.Concat(player).ToArray();
        
        foreach (GameObject currentEnemy in final_array)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                //en yakýn karakter target olarak seçilir
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
            anim.SetBool("isRunning", true);
            nav.SetDestination(closestEnemy.transform.position);
        }
        
        return closestEnemy;
    }

    IEnumerator waitThreeSeconds()
    {
        //oyun baþýnda Tom'un beklemesi
        nav.isStopped = true;       
        yield return new WaitForSeconds(2);
        nav.isStopped = false;
    }
}
