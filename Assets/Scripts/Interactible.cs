using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public UnityEvent OnInteract;
    public UnityEvent OnEnteredRange;
    public UnityEvent OnExitedRange;
    public bool interactionEnabled = true;
    private bool withinRange;

    private void Start()
    {
        withinRange = false;

        Player.instance.GetComponent<PlayerInputProcessor>().Interact.AddListener(interact);
    }

    public void setInteractionEnabled(bool enabled)
    {
        interactionEnabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactionEnabled && collision.gameObject == Player.instance.gameObject)
        {
            OnEnteredRange.Invoke();
            OnTriggerStay2D(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            withinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            withinRange = false;
            OnExitedRange.Invoke();
        }
    }

    private void interact()
    {
        if (withinRange && interactionEnabled)
        {
            OnInteract.Invoke();
        }
    }
}
