using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public GameObject timerContainer;
    public TMP_Text timerElement;
    private DateTime startTime;
    private bool timerActive;


    private void Update()
    {
        timerContainer.SetActive(SpeedrunMode.speedrunMode);
    }

    private void Start()
    {
        startTimer();
    }

    public void toggleTimer(bool active)
    {
        timerActive = active;
    }

    public void startTimer()
    {
        timerActive = true;
        StartCoroutine(time());
    }

    public void stopTimer()
    {
        timerActive = false;
    }

    private IEnumerator time()
    {
        startTime = DateTime.Now;
        while (timerActive)
        {
            timerElement.text = (DateTime.Now - startTime).ToString();
            yield return null;
        }
    }
}
