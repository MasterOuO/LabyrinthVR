using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion look = coin.transform.rotation;
        coin.transform.rotation = Quaternion.Euler(0f, look.eulerAngles.y+1f, 0f);
    }
}
