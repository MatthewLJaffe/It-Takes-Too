using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBasedOnVelocity : MonoBehaviour
{
    public Rigidbody2D rb;

    private bool flipLocked;
    private int multiplier;
    private void FixedUpdate()
    { 
        if (!flipLocked && Mathf.Abs(rb.velocity.x) > 0)
        {
            if(gameObject.CompareTag("Player"))
            {
                multiplier = rb.velocity.x > 0 ? 1 : -1;
            }
            else 
            {
                multiplier = rb.velocity.x > 0 ? -1 : 1;
            }
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * multiplier,
                                     transform.localScale.y,
                                     transform.localScale.z);
        }
    }

    public void lockFlip(bool locked)
    {
        flipLocked = locked;
    }
}
