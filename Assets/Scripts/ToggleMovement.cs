using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMovement : MonoBehaviour
{
    public void toggle(bool enabled)
    {
        Player.instance.GetComponent<PlayerControllerMarty>().movementEnabled = enabled;
        Player.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
