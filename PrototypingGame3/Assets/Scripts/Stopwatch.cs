using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timeText;
    public float timeElapsed;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
        timeText.text = time.ToString("mm':'ss");
    }
}
