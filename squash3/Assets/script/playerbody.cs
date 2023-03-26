using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbody : MonoBehaviour
{
    public GameObject playercamera;
    //public GameObject head;
    public GameObject body;
    public GameObject lightt;
    //public GameObject fall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion look = playercamera.transform.rotation;
        body.transform.rotation = Quaternion.Euler(0f, look.eulerAngles.y, 0f);
        lightt.transform.rotation = Quaternion.Euler(look.eulerAngles.x, look.eulerAngles.y, 0f);
        //fall.transform.rotation = Quaternion.Euler(0f, look.eulerAngles.y, 0f);
    }
}
