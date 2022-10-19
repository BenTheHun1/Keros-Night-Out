using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockTime : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public int clockTimeMin = 10;
    private float curSec;
    private int clockTimeHour = 9;
    private int timeCountMultiplier = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       curSec =+ Time.time;
       Debug.Log(curSec);
        clockText.text = clockTimeHour + ":" + clockTimeMin;
        if (curSec > 20 * timeCountMultiplier)
        {
            clockTimeMin++;
            timeCountMultiplier++;
        }
    }
}
