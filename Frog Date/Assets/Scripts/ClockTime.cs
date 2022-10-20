using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Fungus;
using Unity.VisualScripting;

public class ClockTime : MonoBehaviour
{
    public Flowchart flowchart;
    public TextMeshProUGUI text;
    public string clockTime;
    private float curSec;
    private int clockTimeMin = 10;
    private int clockTimeHour = 9;
    private int timeCountMultiplier = 1;

    void Update()
    {
       curSec =+ Time.time;
       Debug.Log(curSec);
       clockTime = clockTimeHour + ":" + clockTimeMin;
       flowchart.SetStringVariable("ClockTime", clockTime);
       if (curSec > 60 * timeCountMultiplier)
       {
            clockTimeMin++;
            timeCountMultiplier++;
       }
    }

    public void Test()
    {
        text.text = "Success";
    }
}
