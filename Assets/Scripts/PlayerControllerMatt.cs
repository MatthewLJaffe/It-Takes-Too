using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMatt : MonoBehaviour {
    public Rigidbody2D rb;
    public GroundChecker groundChecker;
    public PhysicsMaterial2D friction;
    public PhysicsMaterial2D noFriction;
    private Vector2 direction;
    public float jumpForce = 350f;
    private float speed;
    public float fallMultiplier = 1.5f;
    private float gScale;

    void Start() {
        direction = new Vector2(0, 0);
        speed = 4.0f;
        gScale = rb.gravityScale;


    }

    private void FixedUpdate() {
        //lateral movement
        if (Input.GetAxis("Horizontal") != 0) {
            direction.x = Input.GetAxis("Horizontal") * speed;
            direction.y = rb.velocity.y;
            rb.velocity = direction;
        }

        //ground check
        if (groundChecker.isGrounded) {
            rb.gravityScale = gScale;
            rb.sharedMaterial = friction;
        }
        else 
        {
            rb.sharedMaterial = noFriction;
            if (rb.velocity.y < 2) 
            {
                rb.gravityScale = gScale * fallMultiplier;
            }
        }
    }
    public void jump() 
    {
        if (groundChecker.isGrounded) {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
