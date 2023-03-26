using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    private new Transform transform; // 此處使用new關鍵字隱藏父類的同名成員
    private CharacterController controller;
    private Transform cameraTransform; // 攝像機的Transform元件
    private Vector3 cameraRotation; // 攝像機旋轉角度
    private float cameraHeight = 2.5f; // 攝像機高度（即主角的眼睛高度）

    float speed = 0.3f;
    plugindemo test;

    void Start()
    {
        test = GetComponent<plugindemo>();

        transform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        // 獲取攝像機
        cameraTransform = Camera.main.GetComponent<Transform>();
        // 設定攝像機初始位置
        Vector3 position = transform.position;
        position.y += cameraHeight;
        cameraTransform.position = position;
        // 設定攝像機的初始旋轉方向
        cameraTransform.rotation = transform.rotation;
        cameraRotation = cameraTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.eulerAngles = cameraRotation;
        // 使主角的面向方向與攝像機一致
        Vector3 rotation = cameraTransform.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        transform.eulerAngles = rotation;
        // 使攝像機的位置與主角一致
        Vector3 position = transform.position;
        position.y += cameraHeight;
        cameraTransform.position = position;

        float x = 0, y = 0, z = 0;
        // 重力運動
        //y -= gravity * Time.deltaTime;
        // 前後移動
        if (test.getc() >= 1)
        {
            z += speed ;
        }
        else if (test.getc() <= -1)
        {
            z -= speed ;
        }
        // 左右移動
        if (test.getb()<=-1)
        {
            x -= speed ;
        }
        else if (test.getb()>=1)
        {
            x += speed;
        }
        // 使用Character Controller而不是Transform提供的Move方法
        // 因為Character Controller提供的Move方法會自動進行碰撞檢測
        controller.Move(transform.TransformDirection(new Vector3(x, y, z))*Time.deltaTime);

        /* if(test.geta()>1)
         transform.Translate(0, 0, 0);
        if (test.getb() >= 1|| test.getb() <= -1)
            transform.Translate(test.getb() * speed, 0, 0);
        if (test.getc() >= 1 || test.getc() <= -1)
            transform.Translate(0, 0, test.getc() * speed);*/
    }
}
