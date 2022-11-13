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
    private float totalSec, curSec;
    private int clockTimeMin = 10;
    private int clockTimeHour = 9;
    public GameObject optionButton0;

    private GameObject[] Clickables;

    private bool waiter1, star, date_arrive, date_work, date_dates, waiter2;


    private void Start()
    {
        flowchart.StopAllBlocks();
        Time.timeScale = 1;
        Clickables = GameObject.FindGameObjectsWithTag("clickable");
    }

    void Update()
    {
        totalSec += Time.deltaTime;
        curSec += Time.deltaTime;
        //Debug.Log(curSec);
        clockTime = clockTimeHour + ":" + clockTimeMin;
        flowchart.SetStringVariable("ClockTime", clockTime);
        if (curSec >= 60f)
        {
            clockTimeMin++;
            curSec -= 60f;
        }

        if (!flowchart.HasExecutingBlocks() && !optionButton0.activeSelf)
        {
            if (!waiter1 && (totalSec >= 40f || Input.GetKeyDown(KeyCode.Backspace))) {
                waiter1 = true;
                flowchart.ExecuteBlock("Waiter1");
            }
            else if (!star && (totalSec >= 80f || Input.GetKeyDown(KeyCode.Backspace)))
            {
                star = true;
                flowchart.ExecuteBlock("ShootStar");
            }
            else if (!date_arrive && (totalSec >= 120f || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_arrive = true;
                flowchart.ExecuteBlock("DateHere");
            }
            else if (!date_work && (totalSec >= 160f || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_work = true;
                flowchart.ExecuteBlock("DateJob");
            }
            else if (!date_dates && (totalSec >= 200f || Input.GetKeyDown(KeyCode.Backspace)))
            {
                date_dates = true;
                flowchart.ExecuteBlock("DateDates");
            }
            else if (!waiter2 && (totalSec >= 240f || Input.GetKeyDown(KeyCode.Backspace)))
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
