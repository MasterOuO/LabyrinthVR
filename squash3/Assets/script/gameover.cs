using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameover : MonoBehaviour
{
    public GameObject reset;
    public GameObject Instantiate_Position;
    public GameObject playercamera;
    public bool arrive=false;
   

    void OnTriggerEnter(Collider other)
    {
        
        //Destroy(other.gameObject);
        Vector3 move = Instantiate_Position.transform.position;
        if (other.gameObject.tag == "final")
        {
            arrive = true;
            Destroy(other.gameObject);
            Quaternion look = playercamera.transform.rotation;
            if(315< look.eulerAngles.y ||(-45 < look.eulerAngles.y&& look.eulerAngles.y<=45))
                Instantiate(reset,new Vector3(move.x , move.y, move.z+1.5f ), Quaternion.Euler(0, 0, 0));
            if (45 < look.eulerAngles.y && look.eulerAngles.y <= 135)
                Instantiate(reset, new Vector3(move.x+1.5f, move.y, move.z ), Quaternion.Euler(0, 90, 0));
            if ((135 < look.eulerAngles.y && look.eulerAngles.y  <= 225)|| (-225<= look.eulerAngles.y &&look.eulerAngles.y <= -135))
                Instantiate(reset, new Vector3(move.x, move.y , move.z - 1.5f), Quaternion.Euler(0, 180, 0));
            if (-135 < look.eulerAngles.y && look.eulerAngles.y <= -45||(225 < look.eulerAngles.y && look.eulerAngles.y <= 315))
                Instantiate(reset, new Vector3(move.x -1.5f, move.y, move.z ), Quaternion.Euler(0, -90, 0));
        }
    }

    void Start()
    {
        arrive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (arrive)
        {
           // Invoke("restart", 3f);
            arrive = false;
        }*/

    }
    void restart()
    {
        SceneManager.LoadScene(0);
    }



}
