using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteEvent : MonoBehaviour
{
    public GameEvent toComplete;

    public void completeEvent()
    {
        completeEvent(toComplete);
    }

    public void completeEvent(GameEvent theEvent)
    {
        EventTracker.completeEvent(theEvent);
    }
}
