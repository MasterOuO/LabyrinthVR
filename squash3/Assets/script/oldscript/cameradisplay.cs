﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameradisplay : MonoBehaviour
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
        tm.text = player.transform.position.x.ToString();

    }
}
