using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public GameObject player;
    //public GameObject player2;
    void Start()
    {
        InvokeRepeating("counttime", 1, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void counttime()
    {
        if (player.GetComponent<gameover>().arrive==false)
        {
            gettime.time += 1;
            //Debug.Log(gettime.time);
        }
        
    }
   

}
