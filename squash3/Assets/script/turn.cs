using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class turn : MonoBehaviour
{
    public AudioClip whitesound;
    //private bool timerLock = false;
    public GameObject square;
    private bool red;
    private bool green;
    int i;
    //float lerp_tm = 0.1f;
    private bool ready = false;
    private AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        red = false;
        green = false;
        m_AudioSource = GetComponent<AudioSource>();
    }
    /* private IEnumerator delay(float time)
     {
         timerLock = true;
         yield return new WaitForSeconds(time);
         timerLock = false;
     }*/
    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount == 1)
        {
            ready = true;
        }
        else if (Input.touchCount == 0 && ready == true)
        {
            if (red)
            {
                //square.transform.Rotate(0, 90, 0);
                if (square.transform.eulerAngles.y == -90 || square.transform.eulerAngles.y == 270)
                    GetComponent<Animation>().Play("left");
                else if (square.transform.eulerAngles.y == 0 || square.transform.eulerAngles.y == -360)
                    GetComponent<Animation>().Play("leftII");
                else if (square.transform.eulerAngles.y == 90 || square.transform.eulerAngles.y == -270)
                    GetComponent<Animation>().Play("leftIII");
                else if (square.transform.eulerAngles.y == 180 || square.transform.eulerAngles.y == -180)
                    GetComponent<Animation>().Play("leftIIII");
                Debug.Log(red); green = false;
                if (whitesound != null)
                { 
                    m_AudioSource.clip = whitesound;
                    m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }


            }

            else if (green)
            {
                //square.transform.Rotate(0, -90, 0);
                if (square.transform.eulerAngles.y == 0 || square.transform.eulerAngles.y == -360)
                    GetComponent<Animation>().Play("right");
                if (square.transform.eulerAngles.y == -90 || square.transform.eulerAngles.y == 270)
                    GetComponent<Animation>().Play("rightII");
                if (square.transform.eulerAngles.y == 180 || square.transform.eulerAngles.y == -180)
                    GetComponent<Animation>().Play("rightIII");
                if (square.transform.eulerAngles.y == 90 || square.transform.eulerAngles.y == -270)
                    GetComponent<Animation>().Play("rightIIII");
                Debug.Log(red);
                if (whitesound != null)
                {
                    m_AudioSource.clip = whitesound;
                    m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }

            }
            ready = false;
        }
        if (Input.GetMouseButtonUp(0))
        {

            if (red)
            {
                //square.transform.Rotate(0, 90, 0);
                if (square.transform.eulerAngles.y == -90 || square.transform.eulerAngles.y == 270)
                    GetComponent<Animation>().Play("left");
                else if (square.transform.eulerAngles.y == 0 || square.transform.eulerAngles.y == -360)
                    GetComponent<Animation>().Play("leftII");
                else if (square.transform.eulerAngles.y == 90 || square.transform.eulerAngles.y == -270)
                    GetComponent<Animation>().Play("leftIII");
                else if (square.transform.eulerAngles.y == 180 || square.transform.eulerAngles.y == -180)
                    GetComponent<Animation>().Play("leftIIII");
                Debug.Log(red); green = false;
                if (whitesound != null)
                {
                    m_AudioSource.clip = whitesound;
                    m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }
            }

            else if (green)
            {
                //square.transform.Rotate(0, -90, 0);
                if (square.transform.eulerAngles.y == 0 || square.transform.eulerAngles.y == -360)
                    GetComponent<Animation>().Play("right");
                if (square.transform.eulerAngles.y == -90 || square.transform.eulerAngles.y == 270)
                    GetComponent<Animation>().Play("rightII");
                if (square.transform.eulerAngles.y == 180 || square.transform.eulerAngles.y == -180)
                    GetComponent<Animation>().Play("rightIII");
                if (square.transform.eulerAngles.y == 90 || square.transform.eulerAngles.y == -270)
                    GetComponent<Animation>().Play("rightIIII");
                //Debug.Log(red);
                if (whitesound != null)
                {
                    m_AudioSource.clip = whitesound;
                    m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }
            }
        }
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
