using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckEventCompleted : MonoBehaviour
{
    public GameEvent toCheck;
    public UnityEvent EventWasCompleted;
    public bool checkContinuously;

    private bool eventWasComplete;

    public void checkEvent()
    {
        eventWasComplete = false;
        StartCoroutine(checkTheEvent(toCheck));
    }

    private IEnumerator checkTheEvent(GameEvent toCheck)
    {
        do
        {
            checkEvent(toCheck);
            yield return null;
        }
        while (checkContinuously && !eventWasComplete);
    }

    public void checkEvent(GameEvent theEvent)
    {
        if (EventTracker.eventWasCompleted(theEvent))
        {
            EventWasCompleted.Invoke();
            eventWasComplete = true;
        }
    }
}
