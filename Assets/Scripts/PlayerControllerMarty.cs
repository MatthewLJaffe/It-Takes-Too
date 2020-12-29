using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMarty : MonoBehaviour
{
    public Rigidbody2D rb;
    public GroundChecker groundChecker;
    public bool movementEnabled = true;
    private Vector2 direction;
    public float acceleration = 5f;
    public float friction = 2f;
    public float jumpForce = 20f;
    private float gScale;
    public float fallMultiplier = 2;
    public string moveAnimatorParam = "move";
    public string aerialAnimatorBool = "aerial";

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        direction = new Vector2(0, 0);
        gScale = rb.gravityScale;
        
    }

    private void FixedUpdate() 
    {
        if (movementEnabled)
        {
            direction.x = Input.GetAxis("Horizontal");
            //direction.y = rb.velocity.y;
            //rb.velocity = direction;
            rb.AddForce(new Vector2(direction.x, 0) * acceleration);
            rb.AddForce(new Vector2(rb.velocity.x, 0) * -friction);

            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gScale * fallMultiplier;
            }
            else
            {
                rb.gravityScale = gScale;
            }

            anim.SetFloat(moveAnimatorParam, direction.x);
            anim.SetBool(aerialAnimatorBool, !groundChecker.isGrounded);
        }
        else
        {
            anim.SetFloat(moveAnimatorParam, 0);
        }
    }

    public void setMovement(bool enabled)
    {
        movementEnabled = enabled;
    }

    public void jump()
    {
        if (movementEnabled && groundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

}
