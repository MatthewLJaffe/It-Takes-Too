using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public float speed;
    public BoxCollider2D box;
    private float timeSinceJump;
    public float jumpCooldown = 4f;
    public float acceleration;
    public float friction;
    public float jumpForce = 200;
    public float minHeightDifference = .2f;
    private bool agro = false;
    public float agroDistance = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        timeSinceJump = jumpCooldown;
        if (target == null)
        {
            target = Player.instance.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(((transform.position-target.position).magnitude)) < agroDistance) {
            agro = true;
        }
        if (agro) 
        {
            if (rb.position.x - target.position.x > 0 && canMoveRight()) {

                rb.AddForce(new Vector2(-1, 0) * acceleration);
                rb.AddForce(new Vector2(rb.velocity.x, 0) * -friction);
            }
            if (rb.position.x - target.position.x < 0 && canMoveLeft()) {
                rb.AddForce(new Vector2(1, 0) * acceleration);
                rb.AddForce(new Vector2(rb.velocity.x, 0) * -friction);
            }
            enemyJump();
        }

    }

    private bool canMoveRight() {
        RaycastHit2D groundedRight = Physics2D.Raycast(new Vector2(rb.position.x - box.size.x / 2, rb.position.y),Vector2.down,4,LayerMask.GetMask("ground"));
        Debug.DrawRay(new Vector2(transform.position.x - box.size.x / 2, transform.position.y), Vector2.down * box.size.y,Color.green);
        if(groundedRight.collider == null) {
            if (jumpCooldown <= timeSinceJump) {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            return false;
        }
        return true;
    }
    
    private bool canMoveLeft() {
        RaycastHit2D groundedRight = Physics2D.Raycast(new Vector2(rb.position.x + box.size.x / 2, rb.position.y), Vector2.down, 4, LayerMask.GetMask("ground"));
        Debug.DrawRay(new Vector2(rb.position.x + box.size.x / 2, rb.position.y), Vector2.down * box.size.y, Color.green);
        if (groundedRight.collider == null) {
            if(jumpCooldown <= timeSinceJump) {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            return false;
        }
        return true;
       
    }

    private void enemyJump() {
        if(target.position.y - rb.position.y > minHeightDifference && timeSinceJump >= jumpCooldown) {
            rb.AddForce(Vector2.up * jumpForce);
            timeSinceJump = 0;
        }
        timeSinceJump += Time.deltaTime;
    }
}
