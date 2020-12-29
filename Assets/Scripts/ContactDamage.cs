using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public int damage = 1;
    public string opponentTag = "Player";

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(opponentTag))
        {
            Health opponentHealth = collision.gameObject.GetComponent<Health>();

            if (opponentHealth != null)
            {
                opponentHealth.damage(damage, transform);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(opponentTag))
        {
            Health opponentHealth = collision.GetComponent<Health>();

            if (opponentHealth != null)
            {
                opponentHealth.damage(damage, transform);
            }
        }
    }
}
