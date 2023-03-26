using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display2 : MonoBehaviour
{
    TextMesh tm;
    plugindemo test;
    Vector3 rotationVelocity;
    void Start()
    {
        tm = transform.GetComponent<TextMesh>();
        test = GetComponent<plugindemo>();

        Input.gyro.enabled = true;

        Input.gyro.updateInterval = 0.1f;
    }
    void Update()
    {
        rotationVelocity = Input.gyro.rotationRate;
        tm.text = rotationVelocity.ToString();

    }
}
