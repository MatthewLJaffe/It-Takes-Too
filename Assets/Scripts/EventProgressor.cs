using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventProgressor : MonoBehaviour
{
    public bool trackCompletion = true;

    public static List<string> progressors;

    [SerializeField]
    private int currEvent;
    public int CurrentEvent => currEvent;

    private void Awake()
    {
        if (progressors == null)
        {
            progressors = new List<string>();
        }

        if (progressors.Find(n => n.Equals(name)) != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currEvent = -1;

        invokeNextEvent();
    }

    private void invokeNextEvent()
    {
        currEvent++;

        if (currEvent < transform.childCount)
        {
            RunnableEvent next = transform.GetChild(currEvent).GetComponent<RunnableEvent>();
            next.Complete.AddListener(invokeNextEvent);
            next.Start.Invoke();
        }
        else
        {
            Debug.Log(name + " Completed all events");
            if (trackCompletion)
            {
                progressors.Add(name);
            }
        }
    }

}
