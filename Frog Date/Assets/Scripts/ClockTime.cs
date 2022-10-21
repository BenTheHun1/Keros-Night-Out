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
    private float timer = 0.0f;
    private float curSec;
    private int clockTimeMin = 10;
    private int clockTimeHour = 9;
    private int timeCountMultiplier = 1;

    private GameObject[] Clickables;

    private bool waiter1, date_arrive, date_work, date_dates, waiter2;


    private void Start()
    {
        flowchart.StopAllBlocks();
        Time.timeScale = 1;
        Clickables = GameObject.FindGameObjectsWithTag("clickable");
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        curSec = (float)(timer);
        Debug.Log(curSec);
        clockTime = clockTimeHour + ":" + clockTimeMin;
        flowchart.SetStringVariable("ClockTime", clockTime);
        if (curSec > 60 * timeCountMultiplier)
        {
            clockTimeMin++;
            timeCountMultiplier++;
        }

        if (!flowchart.HasExecutingBlocks())
        {
            if (!waiter1 && (timeCountMultiplier == 2 || Input.GetKeyDown(KeyCode.Backspace))) {
                waiter1 = true;
                flowchart.ExecuteBlock("Waiter1");
            }
            else if (!date_arrive && (timeCountMultiplier == 4 || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_arrive = true;
                flowchart.ExecuteBlock("DateHere");
            }
            else if (!date_work && (timeCountMultiplier == 5 || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_work = true;
                flowchart.ExecuteBlock("DateJob");
            }
            else if (!date_dates && (timeCountMultiplier == 6 || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_dates = true;
                flowchart.ExecuteBlock("DateDates");
            }
            else if (!waiter2 && (timeCountMultiplier == 7 || Input.GetKeyDown(KeyCode.Backspace)))
            {
                waiter2 = true;
                flowchart.ExecuteBlock("Waiter2");
            }
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
