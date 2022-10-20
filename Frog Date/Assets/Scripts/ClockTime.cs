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

    private GameObject[] Clickables;

    private void Start()
    {
        Clickables = GameObject.FindGameObjectsWithTag("clickable");
    }


    void Update()
    {
        curSec =+ Time.time;
        //Debug.Log(curSec);
        clockTime = clockTimeHour + ":" + clockTimeMin;
        flowchart.SetStringVariable("ClockTime", clockTime);
        if (curSec > 60 * timeCountMultiplier)
        {
            clockTimeMin++;
            timeCountMultiplier++;
        }


        if (flowchart.GetBooleanVariable("Interact") == true)
        {
            foreach (GameObject clickable in Clickables)
            {
                clickable.GetComponent<Clickable2D>().ClickEnabled = true;
            }
        }
        else
        {
            foreach (GameObject clickable in Clickables)
            {
                clickable.GetComponent<Clickable2D>().ClickEnabled = false;
            }
        }
    }
}
