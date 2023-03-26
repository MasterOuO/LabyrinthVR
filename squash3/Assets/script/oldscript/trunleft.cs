using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trunleft : MonoBehaviour
{
    public GameObject square;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        square.transform.Rotate(0, 90, 0);
    }
}
