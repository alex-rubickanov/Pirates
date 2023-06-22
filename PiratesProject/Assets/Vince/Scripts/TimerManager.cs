using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] float maxTime = 120f;
    [SerializeField] Slider timerSlider;
    void Start()
    {
        timerSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        BeginCountDown();
    }

    private void BeginCountDown()
    {
        timerSlider.value -= Time.deltaTime;
    }

    public float GetTime
    {
       get { return timerSlider.value; }
    }
}
