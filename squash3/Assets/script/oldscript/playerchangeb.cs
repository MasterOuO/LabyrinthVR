using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerchangeb : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public GameObject girl;
    public GameObject boy;
    void Start()
    {
       
        if (playerchangedata.woman == 1)
            Instantiate(girl, new Vector3(0, 2, 0), Quaternion.Euler(0, 0, 0));
        else
            Instantiate(boy, new Vector3(0, 2, 0), Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
