using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerchangebII : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public GameObject woman;
    public GameObject man;
    public GameObject player;
    public GameObject body;
    private GameObject Clone;
    void Start()
    {
        if (playerchangedata.woman == 1)
        {
            Vector3 move = player.transform.position;
            Quaternion rotat = body.transform.rotation;
            Destroy(GameObject.Find("Actor"));
            Clone = Instantiate(woman, new Vector3(move.x, move.y - 1.77f, move.z - 0.26f), Quaternion.Euler(0, rotat.eulerAngles.y, 0), body.transform);
            Clone.name = "Actor";
            //Instantiate(girl, new Vector3(42, 2, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Vector3 move = player.transform.position;
            Quaternion rotat = body.transform.rotation;
            Destroy(GameObject.Find("Actor"));
            Clone = Instantiate(man, new Vector3(move.x, move.y - 1.9f, move.z - 0.1f), Quaternion.Euler(0, rotat.eulerAngles.y, 0), body.transform);
            Clone.name = "Actor";
        }
            //Instantiate(boy, new Vector3(42, 2, 0), Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
