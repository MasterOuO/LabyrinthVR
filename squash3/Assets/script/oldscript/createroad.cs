using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createroad : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject player;
    public GameObject camera;
    //Vector3 move = GameObject.Find("Instantiate_Position").transform.position;

    public GameObject straight;
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public GameObject three;
    public GameObject four;
    public GameObject die;
    public GameObject end;
    //min 紀錄位置軸最小 max紀錄位置軸最大
    public float xmin, ymin, zmin, xmax, ymax, zmax;
    public float i,j;
    int a;
    int x, y, z, speed;
    int[,,] list;
    int xlocation, ylocation, zlocation;
    void Start()
    {
        a = 1;
        //Vector3 move = Instantiate_Position.transform.position;
        speed = 6;
        x = 0;
        y = 0;
        z = 0;
        xmin = 2.9f;ymin = 0f;zmin = 2.9f;xmax = 2.9f;ymax = 0f;zmax = 2.9f;
        xlocation = 0; ylocation = 0; zlocation = 0;
        //list[0, 0, 0] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) a = 1;
        if (Input.GetKey(KeyCode.X)) a = 2;
        if (Input.GetKey(KeyCode.C)) a = 3;
        if (Input.GetKey(KeyCode.V)) a = 4;
        if (Input.GetKey(KeyCode.B)) a = 5;
        if (Input.GetKey(KeyCode.N)) a = 6;
        if (Input.GetKey(KeyCode.M)) a = 7;
        if (Input.GetKey(KeyCode.Q)) a = 8;
        if (Input.GetKey(KeyCode.E)) a = 9;


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 move = Instantiate_Position.transform.position;
            Vector3 playermove = player.transform.position;

            //抓所在角色目前踩的方塊中心點

            // -2.9~2.9 抓到位置為0
            /*for ( i= xmin ; i <= xmax ; i += 6)
            {
                j = i - 5.8f;
                if(j<= playermove.x && playermove.x <= i)
                {
                    xlocation =(int)( i - 2.9f);
                    break;
                }
            }
            // y 0~6
            for (i = ymin; i <= ymax; i += 6f)
            {
                j = i + 6f;
                if (i <= playermove.y && playermove.y <= j)
                {
                    ylocation = (int)(i);
                    break;
                }
            }
            // z 
            for (i = zmin; i <= zmax; i += 6f)
            {
                j = i - 5.8f;
                if (j <= playermove.z && playermove.z <= i)
                {
                    zlocation = (int)(i - 2.9f);
                    break;
                }
            }*/
            //看預設地方有無方塊

            /*if (list[xlocation,ylocation,zlocation + speed] == 0)
            {*/
            Quaternion look = camera.transform.rotation;
            //前
            if ((315 < look.eulerAngles.y && look.eulerAngles.y <= 360) || (0 <= look.eulerAngles.y && look.eulerAngles.y <= 45) || (-315 > look.eulerAngles.y && look.eulerAngles.y >= -360)||( look.eulerAngles.y <= 0&&look.eulerAngles.y >= -45))
            { 
                if (a == 1)
                {
                    z += speed;
                    Instantiate(straight, new Vector3(move.x + x, move.y, move.z + z), Instantiate_Position.transform.rotation, Instantiate_Position.transform);
                    
                    //list[xlocation, ylocation, zlocation+speed] = 1;
                }
            }
            //右
            if ((45 < look.eulerAngles.y && look.eulerAngles.y <= 135) || (-315 < look.eulerAngles.y && look.eulerAngles.y <= -225))
            {
                if (a == 1)
                {
                    x += speed;
                    Instantiate(straight, new Vector3(move.x + x, move.y, move.z + z ), Quaternion.Euler(0, 90, 0), Instantiate_Position.transform);
                    
                    //list[xlocation, ylocation, zlocation+speed] = 1;
                }
            }
            //後
            if ((135 < look.eulerAngles.y && look.eulerAngles.y <= 225 )||( -225 < look.eulerAngles.y && look.eulerAngles.y <= -135)) 
            {
                if (a == 1)
                {
                    z -= speed;
                    Instantiate(straight, new Vector3(move.x +x, move.y, move.z + z), Instantiate_Position.transform.rotation, Instantiate_Position.transform);
                    
                    //list[xlocation, ylocation, zlocation+speed] = 1;
                }
            }
            //左
            if ((225 < look.eulerAngles.y && look.eulerAngles.y <= 315) || (-135 < look.eulerAngles.y && look.eulerAngles.y <= -45)) 
            {
                if (a == 1)
                {
                    x -= speed;
                    Instantiate(straight, new Vector3(move.x + x, move.y, move.z + z ), Quaternion.Euler(0, 90, 0), Instantiate_Position.transform);
                    
                    //list[xlocation, ylocation, zlocation+speed] = 1;
                }
            }

                if (a == 2)
                {
                    Instantiate(left, new Vector3(move.x + x, move.y + y, move.z + z), Instantiate_Position.transform.rotation, Instantiate_Position.transform);
                    z += speed;
                }
                if (a == 3) Instantiate(right, Instantiate_Position.transform);
                if (a == 4) Instantiate(up, Instantiate_Position.transform);
                if (a == 5) Instantiate(down, Instantiate_Position.transform);
                if (a == 6) Instantiate(three, Instantiate_Position.transform);
                if (a == 7) Instantiate(four, Instantiate_Position.transform);
                if (a == 8) Instantiate(die, Instantiate_Position.transform);
                if (a == 9) Instantiate(end, Instantiate_Position.transform);
            //}
        }

    }
    
}
