using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerCount : MonoBehaviour
{
    private Text timerText;
    private float time;
    private int currentTime;
    public static bool stop = false;
    void Start()
    {
        timerText = GetComponent<Text>();
    }
    void Update()
    {
        if (stop)
        {
            time += Time.deltaTime;
            currentTime = (int)time;
            timerText.text = "Timer :" + currentTime;
        }
    }
}
