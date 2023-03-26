using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PointerTester : MonoBehaviour
{
    private bool test;
    private bool ready = false;
    void Awake()
    {
        test = false;
    }
    // Update is called once per frame
    void Update()
    {
        //手機
        if (Input.touchCount == 1)
        {
            ready = true;
        }
        else if (Input.touchCount == 0 && ready == true)
        {
           if (test) SceneManager.LoadScene(0);
        }
        //電腦點擊
        if (Input.GetMouseButtonUp(0))
        {
            if (test) SceneManager.LoadScene(0);

        }
    }
    public void enter( )
    {
        test = true;
        Debug.Log("Pointer is Down");
    }

    public void exit( )
    { 
        test = false;
        Debug.Log("Pointer is Up");
    }
}