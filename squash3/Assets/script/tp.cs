using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tp : MonoBehaviour
{
    private bool start;
    private bool ready;
    private bool red;
    private bool green;
    // Start is called before the first frame update
    void Start()
    {
        red = false;
        start = false;
        ready = false;
        green = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            ready = true;
        }

        else if (Input.touchCount == 0 && ready == true)
        {
            if (start)
            {
                SceneManager.LoadScene(3);
                gettime.time = 0;
            }
            if (red)
            {
                SceneManager.LoadScene(2);
                gettime.time = 0;
            }
            if (green)
            {
                SceneManager.LoadScene(1);
                gettime.time = 0;
            }
            ready = false;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (start)
            {
                SceneManager.LoadScene(3);
                gettime.time = 0;
            }
            if (red)
            {
                SceneManager.LoadScene(2);
                gettime.time = 0;
            }
            if (green)
            {
                SceneManager.LoadScene(1);
                gettime.time = 0;
            }
        }
    }
    public void canstart()
    {
        start = true;
    }
    public void cantstart()
    {
        start = false;
    }
    public void redin()
    {
        red = true;
    }
    public void redout()
    {
        red = false;
    }
    public void greenin()
    {
        green = true;
    }
    public void greenout()
    {
        green = false;
    }
}
