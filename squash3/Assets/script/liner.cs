using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liner : MonoBehaviour
{
    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject jo = null;
    AndroidJavaClass activityClass = null;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
        activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

        jo = new AndroidJavaObject("com.example.mylibrary.liner");
        jo.Call("init", activityContext);
        #endif
    }

   
        public float getLux()
        {
            
            return jo.Call<float>("getLux");
           
        }
        public float getLux2()
        {
          
            return jo.Call<float>("getLux2");
          
        }
        public float getLux3()
        {
            
            return jo.Call<float>("getLux3");
            
        }
}
