using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    public Transform source;
    public UnityEvent OnTriggerEnter;
    private bool listening;

    public void startListening()
    {
        listening = true;
    }

    public void stopListening()
    {
        listening = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == source && listening)
        {
            OnTriggerEnter.Invoke();
            listening = false;
        }
    }

}
