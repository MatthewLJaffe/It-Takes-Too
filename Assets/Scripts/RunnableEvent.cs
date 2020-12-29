using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnableEvent : MonoBehaviour
{
    public UnityEvent Start;
    public UnityEvent Complete;

    public void beginEvent()
    {
        Start.Invoke();
    }

    public void completeEvent()
    {
        if (transform.parent.GetComponent<EventProgressor>().CurrentEvent == transform.GetSiblingIndex())
        {
            Debug.Log("Completed " + name, gameObject);
            Complete.Invoke();

        }
    }
}
