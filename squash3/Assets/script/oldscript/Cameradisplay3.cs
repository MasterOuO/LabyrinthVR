using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameradisplay3: MonoBehaviour
{
    TextMesh tm;
    public GameObject player;
    void Start()
    {
        tm = transform.GetComponent<TextMesh>();
        //Debug.Log(test.yo);
    }
    void Update()
    {
        tm.text = player.transform.position.z.ToString();

    }
}
