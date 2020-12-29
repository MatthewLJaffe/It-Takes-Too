using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded
    {
        get;
        private set;
    }
    public string groundTag = "Ground";
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerStay2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
