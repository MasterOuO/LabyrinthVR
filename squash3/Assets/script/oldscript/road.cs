using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public GameObject button;
    public GameObject paintpoint;
    public GameObject Instantiate_Position;
    private bool paint;
    private bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        paint = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount == 1)
        {
            ready = true;
        }
        else if (Input.touchCount == 0 && ready == true)
        {
            if (paint)
            {
                Instantiate(paintpoint, new Vector3(Instantiate_Position.transform.position.x, Instantiate_Position.transform.position.y - 2, Instantiate_Position.transform.position.z), Instantiate_Position.transform.rotation);
                ready = false;
            }
        }
        */
        if (Input.GetMouseButton(0))
        {

            if (paint)
            {
                Instantiate(paintpoint, new Vector3(Instantiate_Position.transform.position.x, Instantiate_Position.transform.position.y - 2, Instantiate_Position.transform.position.z+1), Instantiate_Position.transform.rotation);
                
            }
            Debug.Log(paint);

        }
        
        
    }
    public void paintin()
    {
        paint = true;
    }
    public void paintout()
    {
        paint = false;
    }
}
