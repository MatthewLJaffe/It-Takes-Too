using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyBehavior : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public CircleCollider2D col;
    public float speed;
    private Vector2 direction;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        float xDir = Random.Range(-1f, 1f);
        float yDir = Random.Range(-1f, 1f);

        direction = new Vector2(xDir, yDir);
        direction.x /= direction.magnitude;
        direction.y /= direction.magnitude;
        rb.velocity = direction * speed;
        if (target == null) 
        {
            target = Player.instance.transform;
        }

    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (Mathf.Abs((target.position - transform.position).magnitude) > maxDistance) {
            changeDirection();
        }
        
    }

    private void changeDirection() {
        direction = target.position - transform.position;
        direction.x /= direction.magnitude;
        direction.y /= direction.magnitude;
        rb.velocity = direction *speed;

    }

}
