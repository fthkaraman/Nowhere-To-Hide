using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFollow : MonoBehaviour
{
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spot ýþýðý karakteri takip eder
        transform.LookAt(thePlayer.transform);
    }
}
