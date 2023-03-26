using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class throwb : MonoBehaviour
{
    public AudioClip placeclip;
    public GameObject yellow;
    public GameObject playercamera;
    public GameObject player;
    public Slider aimSlider;
    public float balldistance = 2f;
    private float crtForce = 10;
    private float minForce = 10;
    private float maxForce = 25;
    private float forceSpeed = 20;
    public float speed = 5f;
    private float distance;
    private bool holdingball = false;
    private bool ready = false;
    private bool reset = false;
    private AudioSource m_AudioSource;
    public bool shoot;
    float rot;
    plugindemo final;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        final = GetComponent<plugindemo>();
        playercamera.transform.position = new Vector3(0, 2.5f, 0);
                //Debug.Log(playercamera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        aimSlider.value = minForce;

        if (Input.GetMouseButtonDown(0))
        {
            crtForce = minForce;
        }
        else if (Input.GetMouseButton(0))
        {
            crtForce += forceSpeed * Time.deltaTime;
            aimSlider.value = crtForce;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (crtForce > 25)
            {
                fire();
                if (placeclip != null)
                { 
                    m_AudioSource.clip = placeclip;
                    m_AudioSource.PlayOneShot(m_AudioSource.clip);
                }
            }
        }
        /*if (Input.touchCount == 0 && ready == false)
         {
             crtForce = minForce;
         }
         else if (Input.touchCount == 1)
         {
             crtForce += forceSpeed * Time.deltaTime;
             aimSlider.value = crtForce;
             ready = true;
         }
         else if (Input.touchCount == 0 && ready == true)
         {
             if (crtForce > 25)
             { 
                 fire();
                 if (placeclip != null)
                 {
                     m_AudioSource.clip = placeclip;
                     m_AudioSource.PlayOneShot(m_AudioSource.clip);
                 }
             }
             ready = false;
         }*/

        //  Debug.Log(reset);
    }

    public void Icanshoot()
    {
        shoot = true;
    }
    public void noshoot()
    {
        shoot = false;
    }
    public void fire()
    {
        Vector3 move = player.transform.position;
        Quaternion look = playercamera.transform.rotation;
        Instantiate(yellow, new Vector3(move.x, move.y - 1.7f, move.z), Quaternion.Euler(0f, look.eulerAngles.y, 0f));
    }
    public void restart()
    {
        reset = true;
    }
    public void norestart()
    {
        reset = false;
    }

}
