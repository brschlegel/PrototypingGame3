using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timeElapsed;

    private bool timerEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled)
        {
            timeElapsed += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
            timeText.text = time.ToString("mm':'ss");
        }
        
    }

    public string ReturnTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
        return time.ToString("mm':'ss");
    }

    public void StopTimer()
    {
        timerEnabled = false;
    }
}
