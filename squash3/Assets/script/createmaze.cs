using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createmaze : MonoBehaviour
{
    //創建迷宮
    public GameObject maze;
    public GameObject left;
    public GameObject dieroad;
    public GameObject end;
    public GameObject up;
    public GameObject down;
    public int x, y, z;
    int xn, zn;
    int xlocation, zlocation;
    float ylocation, yspeed = 6.046f;
    int[,,] a = new int[100, 6, 100];
    int i, j, k, l;
    int r, r1, creater, xr, xy, xz, ch, an, xru;
    int sz;
    int ox;
    int sw, sw1, notend,sw2;
    int speed;
    int yrotation;
    //從四種角度選一個角度
    int angle()
    {
        creater = UnityEngine.Random.Range(1, 5);
        if (creater == 1) yrotation = 270;
        else if (creater == 2) yrotation = 180;
        else if (creater == 3) yrotation = 90;
        else yrotation = 0;
        return yrotation;
    }
    //選三牆還是二牆方塊
    bool choose()
    {
        creater = UnityEngine.Random.Range(1, 5);
       // Debug.Log(creater);
        if (creater == 4) return false;
        return true;
    }
    //樓梯的入口後面的方塊
    void stairup(int yrotation, int xlocation, int y, int zlocation)
    {
        int creyrotation;
        ylocation = (y - 1) * yspeed;
        creater = UnityEngine.Random.Range(0, 2);
        switch (yrotation)
        {
            case 270:
                xlocation -= 12;
                if (creater == 1) creyrotation = 270;
                else creyrotation = 180;
                break;
            case 180:
                zlocation -= 12;
                if (creater == 1) creyrotation = 180;
                else creyrotation = 90;
                break;
            case 90:
                xlocation += 12;
                if (creater == 1) creyrotation = 90;
                else creyrotation = 0;
                break;
            default:
                zlocation += 12;
                if (creater == 1) creyrotation = 0;
                else creyrotation = 270;
                break;
        }
        Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, creyrotation, 0), maze.transform);
        a[xlocation, y + 1, zlocation] = 2;
    }
    //樓梯的出口前面的方塊
    void stairdown(int yrotation, int xlocation, int y, int zlocation)
    {
        int creyrotation;
        ylocation = (y - 2) * yspeed;
        creater = UnityEngine.Random.Range(0, 2);
        switch (yrotation)
        {
            case 270:
                xlocation += 12;
                if (creater == 1) creyrotation = 90;
                else creyrotation = 0;
                break;
            case 180:
                zlocation += 12;
                if (creater == 1) creyrotation = 0;
                else creyrotation = 270;
                break;
            case 90:
                xlocation -= 12;
                if (creater == 1) creyrotation = 270;
                else creyrotation = 180;
                break;
            default:
                zlocation -= 12;
                if (creater == 1) creyrotation = 180;
                else creyrotation = 90;
                break;
        }
        Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, creyrotation, 0), maze.transform);
        a[xlocation, y, zlocation] = 2;
    }
    
    //end前面的方塊
    void endup(int yrotation, int xlocation, int y, int zlocation)
    {
        int creyrotation;
        ylocation = (y - 1) * yspeed;
        creater = UnityEngine.Random.Range(0, 3);
        switch (yrotation)
        {
            case 270:
                xlocation += 12;
                if (xlocation <= 78)
                {
                    if (creater == 1) creyrotation = 270;
                    else if (creater == 2) creyrotation = 180;
                    else creyrotation = 90;
                }
                else
                {
                    xlocation -= 6;
                    zlocation += 6;
                    if (zlocation <= 78)
                    {
                        if (creater == 1) creyrotation = 180;
                        else if (creater == 2) creyrotation = 90;
                        else creyrotation = 0;
                    }
                    else
                    {
                        zlocation -= 12;
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 180;
                        else creyrotation = 0;
                    }
                }
                break;
            case 180:
                zlocation += 12;
                if (zlocation <= 78)
                {
                    if (creater == 1) creyrotation = 180;
                    else if (creater == 2) creyrotation = 90;
                    else creyrotation = 0;
                }
                else
                {
                    xlocation -= 6;
                    zlocation -= 6;
                    if (xlocation > 0)
                    {
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 90;
                        else creyrotation = 0;
                    }
                    else
                    {
                        xlocation += 12;
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 180;
                        else creyrotation = 90;
                    }
                }

                break;
            case 90:
                xlocation -= 12;

                if (xlocation > 0)
                {
                    if (creater == 1) creyrotation = 90;
                    else if (creater == 2) creyrotation = 0;
                    else creyrotation = 270;
                }
                else
                {
                    xlocation += 6;
                    zlocation -= 6;
                    if (zlocation > 0)
                    {
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 180;
                        else creyrotation = 0;
                    }
                    else
                    {
                        zlocation += 12;
                        if (creater == 1) creyrotation = 180;
                        else if (creater == 2) creyrotation = 90;
                        else creyrotation = 0;
                    }
                }
                break;
            default:
                zlocation -= 12;
                if (zlocation > 0)
                {
                    if (creater == 1) creyrotation = 270;
                    else if (creater == 2) creyrotation = 180;
                    else creyrotation = 0;
                }
                else
                {
                    xlocation += 6;
                    zlocation += 6;
                    if (xlocation <= 78)
                    {
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 180;
                        else creyrotation = 90;
                    }
                    else
                    {
                        xlocation -= 12;
                        if (creater == 1) creyrotation = 270;
                        else if (creater == 2) creyrotation = 90;
                        else creyrotation = 0;
                    }
                }

                break;
        }
        Instantiate(dieroad, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, creyrotation, 0), maze.transform);
        a[xlocation, y + 1, zlocation] = 2;
    }
    void Start()
    {
        y = 3;
        x = 13;
        z = 13;
        speed = 6;
        notend = 1;
        //原點算式(x-0+1)/2*speed
        ox = (x / 2 +1)* speed;
        //Debug.Log(ox);

        //up down 放置
        yrotation = angle();
        Instantiate(up, new Vector3(24, 0, 24), Quaternion.Euler(0, yrotation, 0), maze.transform);
        a[24, 2, 24] = 2;
        a[24, 3, 24] = 2;

        //防止樓梯出入口被牆擋住，設置一個能通的道路
        stairup(yrotation, 24, 2, 24);
        //stairdown(yrotation, 24, 2, 24);

        yrotation = angle();
        Instantiate(up, new Vector3(60, 0, 60), Quaternion.Euler(0, yrotation, 0), maze.transform);
        a[60, 2, 60] = 2;
        a[60, 3, 60] = 2;
        stairup(yrotation, 60, 2, 60);
       // stairdown(yrotation, 60, 2, 60);

        yrotation = angle();
        Instantiate(down, new Vector3(24, -6.046f, 60), Quaternion.Euler(0, yrotation, 0), maze.transform);
        a[24, 2, 60] = 2;
        a[24, 1, 60] = 2;
        //down 的y值要往下一層
        //stairup(yrotation, 24, 1, 60);
        stairdown(yrotation, 24, 1, 60);

        yrotation = angle();
        Instantiate(down, new Vector3(60, -6.046f, 24), Quaternion.Euler(0, yrotation, 0), maze.transform);
        a[60, 2, 24] = 2;
        a[60, 1, 24] = 2;
        //stairup(yrotation, 60, 1, 24);
        stairdown(yrotation, 60, 1, 24);

        while (notend > 0)
        {
            //end 放置
            xy = UnityEngine.Random.Range(0, y);
            //防止終點的x離起點太近
            if (xy == 1)
            {
                xru = UnityEngine.Random.Range(0, 2);
                if (xru == 0) xr = UnityEngine.Random.Range(0, x / 2 - 2);
                else xr = UnityEngine.Random.Range(x / 2 - 2, x);
            }
            else xr = UnityEngine.Random.Range(0, x);
            //x,y,z位置
            xlocation = (x-1) / 2 * speed + ox - xr * speed;
            ylocation = (xy - 1) * yspeed;
            //判斷x為單為雙 單數的格數和每一格軸都不同

            if (((x % 4 == 2|| x % 4 == 3)&&xr%2==0)|| ((x % 4 == 0 || x % 4 == 1) && xr % 2 == 1))
            {
                //防止終點的z離起點太近
                if (xy == 1) xz = UnityEngine.Random.Range(3, z / 2);
                else xz = UnityEngine.Random.Range(0, z / 2);
                if (z % 4 == 3 && xz == z / 2 ) xz--;
                zlocation = (xz + 1) * speed * 2;
                Debug.Log("xz:"+xz);
            }
            else
            {
                if (xy == 1) xz = UnityEngine.Random.Range(3, z / 2 + 1);
                else xz = UnityEngine.Random.Range(0, z / 2 + 1);
                if (z % 4 == 3) xz--;
                zlocation = xz * speed * 2+speed;
            }

            yrotation = angle();
            //判斷終點位置是否以存放過階梯
            if (a[xlocation, xy + 1, zlocation] == 2) continue;
            //判斷在角落的end
            else if (xlocation == 78 && zlocation == 78 && (yrotation == 180 || yrotation == 270)) continue;
            else if (xlocation == 6 && zlocation == 78 && (yrotation == 180 || yrotation == 90)) continue;
            else if (xlocation == 78 && zlocation == 6 && (yrotation == 0 || yrotation == 270)) continue;
            else if (xlocation == 6 && zlocation == 6 && (yrotation == 0 || yrotation == 90)) continue;
            else
            {
                Instantiate(end, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                a[xlocation, xy + 1, zlocation] = 2;
                //防止終點被三個死路方塊卡死
                endup(yrotation, xlocation, xy, zlocation);
                notend = 0;
                break;
            }
        }
        //樓層

        for (i = 1; i <= y; i++)
        {
            zn = (z + 1) / 2;
            sw1 = 0;
            sw2 = 0;
            xn = 1;
            //Debug.Log(zn);
            //前後
            //前五角形
            for (j = 1; j <= zn; j++)
            {
                /*xlocation = ox;
                zlocation = 6;*/
                ylocation = (i - 2) * yspeed;
                //隨機抓取兩個方塊防止死路
                //左邊和中間 1-7
                r = UnityEngine.Random.Range(0, xn/2)+1 ;
                //右邊 8-13 
                r1 = UnityEngine.Random.Range(xn/2, xn) + 1;
                //Debug.Log("  1  " + "r" + r + "r1:" + r1);
                //Debug.Log("r" + r + r1);
                //每一條的初始x,z 
                //2010/7/10改變初始位置的條件 原本預設是給5.9.13大小每次加四格迷宮 現在改為單數都行
                xlocation = ox;
                zlocation = 6;
                xlocation -= speed * (xn / 2);
                zlocation += 2 * speed * sw1 + sw2;
                sw = 0;
                //int rx, rz;
                for (k = 1; k <= xn; k++)
                {
                    //左+中
                    if (k == r)
                    {
                        if (a[xlocation, i, zlocation] == 0)
                        {
                            //隨機抓一種不會死路的其中一個角度的順序
                            //2020/7/10發現1F.3F起點不在於後中方而是樓梯下去或上去
                            //因為是針對起點可以往外走，所以防死路的角度改為兩種變成可以進出
                            creater = UnityEngine.Random.Range(1, 3);
                            //判斷防止死路方塊在左中
                            if (r < xn / 2 + 1)
                            {
                                //左邊的不會死路的3角度
                                if (zlocation == 6)
                                {
                                    //在最後方不會死路為兩個角度
                                    /*if (creater == 1) yrotation = 270;
                                    else yrotation = 180;*/
                                    //2010/7/10改為進出的一種角度
                                    yrotation = 180;
                                }
                                else
                                {
                                    //2010/7/10 3角度改為2角度
                                    if (creater == 1) yrotation = 180;
                                    else yrotation = 0;
                                }
                                
                            }
                            else if (r == xn / 2 + 1)
                            {
                                //中間的不會死路的2角度
                                if (creater == 1) yrotation = 270;
                                else yrotation = 0;
                            }
                            //生成
                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                            a[xlocation, i, zlocation] = 1;
                        }
                        
                    }
                    //右邊
                    if (k == r1)
                    {
                        if (a[xlocation, i, zlocation] == 0)
                        {
                            //2010/7/10做改變 進出
                            creater = UnityEngine.Random.Range(1, 3);
                                if (zlocation == 6)
                                {
                                //在最後方不會死路為兩個角度
                                /*if (creater == 1) yrotation = 0;
                                else yrotation = 90;*/
                                //2010/7/10 改為進出的一種角度
                                yrotation = 90;
                            }
                                //不會死路的三角度
                                //2010/7/10 三角度改為兩角度
                                else
                                {
                                    if (creater == 1) yrotation = 270;
                                    else yrotation = 90;
                                }
                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                            a[xlocation, i, zlocation] = 1;
                        }
                        
                    }
                    //一般生成
                    if (a[xlocation, i, zlocation] == 0)
                    {
                        yrotation = angle();
                        if (choose())
                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                        else
                        {
                            creater = UnityEngine.Random.Range(1, 3);
                            if (i < r)
                            {
                                if (creater == 1) yrotation = 90;
                                else yrotation = 180;
                            }
                            else if(i <= xn / 2 + 1)
                            {
                                if (creater == 1) yrotation = 0;
                                else yrotation = 270;
                            }
                            else if (i < r1)
                            {
                                if (creater == 1) yrotation = 180;
                                else yrotation = 270;
                            }
                            else
                            {
                                if (creater == 1) yrotation = 0;
                                else yrotation = 90;
                            }
                            Instantiate(dieroad, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                        }
                        a[xlocation, i, zlocation] = 1;
                    }
                    xlocation += speed;
                    if (sw == 0) zlocation += speed;
                    else zlocation -= speed;
                    if (xlocation == ox) sw = 1;
                }
                //格數xn 從1加到x為止
                //Debug.Log("xn:"+xn);
                if (xn < x)
                {
                    //xn+4>x xn!=x 7.11等單數跟偶數格數
                    if (xn + 4 > x)
                    {
                        if(z % 4 == 2|| z % 4 == 3) sw2 = speed;
                        //zlocation += 6;
                        xn = x;
                    }
                    else xn += 4;
                }
                else sw1++;

            }
            //角落
            //2010/7/12改變創建順序--->創建到最角落不計算要創幾條
            //zn = (z - 1) / 4;
            //2010/7/12格數計算
            int sx2;
            if (z % 2 == 0)
            {
                xn--;
                sx2 = 1;
            }
            else
            {
                xn -= 3;
                sx2 = 3;
            }
            //for (j = 1; j <= zn; j++)
            //xn<4為到角落
            //int sx = xlocation;
            
            while (xn > 0)
            {
                
                if (xn % 2 == 1) zlocation -= speed;
                xlocation = ox - (x / 2) * speed;
                zlocation += speed*3;
                //ylocation = (i - 2) * yspeed;
                //隨機抓取一個方塊防止死路
                r = UnityEngine.Random.Range(0, xn / 2 + 1) + 1;
                r1 = UnityEngine.Random.Range(xn / 2 + 1, xn) + 1;
                //Debug.Log("  2  "+"xn/2+1:"+ xn/2+1);
                //Debug.Log("  2  "+"r:"+r+"r1:"+r1);
                sw = 0;
                for (k = 1; k <= xn; k++)
                {
                    //if (k == 1) zlocation -= speed * (xn - 1);
                    if (k == r)
                    {
                        if (a[xlocation, i, zlocation] == 0)
                        {
                            //隨機抓一種不會死路的其中一個角度
                            creater = UnityEngine.Random.Range(1, 4);
                            if (creater == 1) yrotation = 270;
                            else if (creater == 2) yrotation = 180;
                            else yrotation = 0;
                            //生成
                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                            a[xlocation, i, zlocation] = 1;
                        }
                    }
                    //右邊防死路
                    if (k == r1)
                    {
                        if (a[xlocation, i, zlocation] == 0)
                        {
                            //2010/7/10做改變 進出
                            creater = UnityEngine.Random.Range(1, 4);
                            if (creater == 1) yrotation = 0;
                            else if (creater == 2) yrotation = 90;
                            else yrotation = 180;

                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                            a[xlocation, i, zlocation] = 1;
                        }

                    }
                    if (a[xlocation, i, zlocation] == 0)
                    {
                        yrotation = angle();
                        if (choose())
                            Instantiate(left, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                        else
                        {
                            creater = UnityEngine.Random.Range(1, 3);
                            if (i < r)
                            {
                                if (creater == 1) yrotation = 90;
                                else yrotation = 180;
                            }
                            else if (i <= xn / 2 + 1)
                            {
                                if (creater == 1) yrotation = 0;
                                else yrotation = 270;
                            }
                            else if (i < r1)
                            {
                                if (creater == 1) yrotation = 180;
                                else yrotation = 270;
                            }
                            else
                            {
                                if (creater == 1) yrotation = 0;
                                else yrotation = 90;
                            }
                            Instantiate(dieroad, new Vector3(xlocation, ylocation, zlocation), Quaternion.Euler(0, yrotation, 0), maze.transform);
                        }
                        a[xlocation, i, zlocation] = 1;
                    }
                    xlocation += speed;
                    //zlocation += speed;
                    if (k == (xn + 1) / 2)
                    {
                        sw = 1;
                        xlocation += sx2 * speed;
                        sx2 += 4;
                        zlocation += speed;
                    }
                    if (sw == 0) zlocation += speed;
                    else zlocation -= speed;
                }
                xn -= 4;
            }
            
            //Instantiate(left, new Vector3( ), maze.transform.rotation, maze.transform);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //Instantiate(player, new Vector3(0, 2, 0), Quaternion.Euler(0, 0, 0));
    }
}
