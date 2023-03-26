using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerchange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star;
    public GameObject woman;
    public GameObject man;
    public GameObject player;
    public GameObject body;
    private GameObject Clone;
    //public bool man;
    //private bool ready = false;
    void Start()
    {
        //woman = 1;
        //man = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void womanin()
    {
        Vector3 move = player.transform.position;
        Quaternion rotat = body.transform.rotation;
        star.transform.position = new Vector3(7.5f, 3f, 23f);
        Destroy(GameObject.Find("Actor"));
        Clone = Instantiate(woman, new Vector3(move.x, move.y - 1.77f, move.z - 0.26f), Quaternion.Euler(0, rotat.eulerAngles.y, 0), body.transform);
        Clone.name = "Actor";

        playerchangedata.woman = 1;
        //GetComponent<MeshFilter>().sharedMesh = woman;
        //man = false;
    }
    public void manin()
    {
        Vector3 move = player.transform.position;
        Quaternion rotat = body.transform.rotation;
        star.transform.position = new Vector3(4.8f, 3f, 23f);
        //man = true;
        Destroy(GameObject.Find("Actor"));
        Clone = Instantiate(man, new Vector3(move.x, move.y-1.9f, move.z-0.1f), Quaternion.Euler(0, rotat.eulerAngles.y, 0), body.transform);
        Clone.name = "Actor";
        playerchangedata.woman = 0;
        //GetComponent<MeshFilter>().sharedMesh = man;
    }

}
