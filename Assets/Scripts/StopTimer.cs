using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    public void stop()
    {
        Player.instance.GetComponent<Timer>().stopTimer();
    }
}
