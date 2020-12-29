using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTracker : MonoBehaviour
{
    public static List<GameEvent> completedEvents;

    public static EventTracker instance;

    public List<GameEvent> completed;

    private void Update()
    {
        completed = completedEvents;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            completedEvents = new List<GameEvent>();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public static void completeEvent(GameEvent toComplete)
    {
        if (!eventWasCompleted(toComplete))
        {
            completedEvents.Add(toComplete);
        }

    }

    public static bool eventWasCompleted(GameEvent toCheck)
    {
        return completedEvents.Contains(toCheck);
    }
}

public enum GameEvent
{
    CleanOBotSequence,
    BoughtFirstItem,
    AcquiredIT,
    FinalPowerup,
    DefeatedBuffBot
}
