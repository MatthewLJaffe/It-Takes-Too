using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeWait : MonoBehaviour
{
    public UnityEvent timeFinished;

    public void wait(float time)
    {
        StartCoroutine(waitForTime(time));
    }

    private IEnumerator waitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        timeFinished.Invoke();
    }
}
