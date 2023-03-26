using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fall : MonoBehaviour
{
    private bool lose;
    private bool arrive;
    private bool ready;
    public GameObject room;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        lose = false;
        ready = false;
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
            if (lose)
            {
                Vector3 move = player.transform.position;
                Instantiate(room, new Vector3(move.x,move.y-2,move.z), Quaternion.Euler(0, 0, 0));
                Invoke("restart", 5f);
                arrive = false;
                ready = false;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (lose)
            {
                Vector3 move = player.transform.position;
                Instantiate(room, new Vector3(move.x, move.y - 2, move.z), Quaternion.Euler(0, 0, 0));
                Invoke("restart", 5f);
                arrive = false;
            }
        }

    }
    void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void fallin()
    {
        lose = true;
    }
    public void fallout()
    {
        lose = false;
    }
}
