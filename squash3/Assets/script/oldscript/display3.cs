using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display3 : MonoBehaviour
{
    TextMesh tm;
    plugindemo test;
    void Start()
    {
        tm = transform.GetComponent<TextMesh>();
        test = GetComponent<plugindemo>();
        //Debug.Log(test.yo);
    }
    void Update()
    {
        tm.text = test.getc().ToString();

    }
}
