using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timedisplay : MonoBehaviour
{
    Text display;
    int thistime;
    int minute;
    gameover test;
    
    void Start()
    {
        display = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        thistime = gettime.time;
        minute = (thistime / 60);
        if (minute%60 == 0)
            minute = 0;
        if(thistime % 60 < 10 && minute % 60 < 10)
            display.text = thistime / 3600 + ":" +"0"+ minute % 60 + ":" + "0" + gettime.time % 60;
        else if(thistime % 60 < 10)
            display.text = thistime / 3600 + ":"  + minute % 60 + ":" + "0" + gettime.time % 60;
        else if (minute % 60 < 10)
            display.text = thistime / 3600 + ":" + "0" + minute % 60 + ":"  + gettime.time % 60;
        else
            display.text = thistime / 3600 + ":"  + minute % 60 + ":"  + gettime.time % 60;
    }
}
