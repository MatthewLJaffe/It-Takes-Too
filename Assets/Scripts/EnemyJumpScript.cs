using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpScript : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public float jumpForce;
    public float jumpCooldown;
    private float timeSinceJump;
    private Vector2 jumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) 
        {
            target = Player.instance.transform;
            timeSinceJump = jumpCooldown;
            jumpDirection = new Vector2(1, 2);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timeSinceJump > jumpCooldown) 
        {
            if(rb.position.x  >  target.position.x) 
            {
                jump(-1);
            }
            else
            {
                jump(1);
            }
            timeSinceJump = 0;
        }
        timeSinceJump += Time.fixedDeltaTime;
    }

    private void jump( int direction) {
        Debug.Log(new Vector2(jumpDirection.x * direction, jumpDirection.y) * jumpForce);
        float xDistance = Mathf.Abs(rb.position.x - target.position.x);
        if(xDistance > 4) {
            xDistance = 4;
        }
        rb.AddForce(new Vector2(jumpDirection.x * direction,jumpDirection.y) * jumpForce *xDistance);
    }
}
