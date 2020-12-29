using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public float stunTime = 0.4f;
    public float invincibilityTime = 1f;
    public float knockbackForce = 250f;
    public UnityEvent OnDamaged;
    public UnityEvent OnStunRecover;
    public UnityEvent OnInvincibilityFinished;
    public UnityEvent OnDeath;
    public UnityEvent OnHeal;
    public bool isInvincible;
    private Rigidbody2D rb;
    [SerializeField]
    private int health;
    public int CurrentHealth => health;

    private void Awake()
    {
        health = maxHealth;
        isInvincible = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.CompareTag("Player")) {
        }

    }

    public void damage()
    {
        damage(1);
    }

    public void damage(int amt)
    {
        damage(amt, transform);
    }

    public void damage(int amt, Transform source)
    {
        if (!isInvincible)
        {
            health -= amt;
            OnDamaged.Invoke();

            if (rb != null)
            {
                Vector2 dir = (transform.position - source.transform.position).normalized;
                rb.AddForce(dir * knockbackForce);
                //rb.AddForce(Vector2.up * knockbackForce);
            }

            if (health <= 0)
            {
                die();
            }
            else
            {
                StartCoroutine(beInvincible());
                StartCoroutine(beStunned());
            }
        }
    }

    private void die()
    {
        OnDeath.Invoke();
        StopAllCoroutines();
        isInvincible = false;
        OnStunRecover.Invoke();
        OnInvincibilityFinished.Invoke();
    }

    IEnumerator beStunned()
    {
        yield return new WaitForSeconds(stunTime);
        OnStunRecover.Invoke();
    }

    IEnumerator beInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
        OnInvincibilityFinished.Invoke();
    }

    public void heal()
    {
        heal(1);
    }

    public void heal(int amt)
    {
        health += amt;
        OnHeal.Invoke();
    }

    public void healToFull()
    {
        setHealth(maxHealth);
        OnHeal.Invoke();
    }

    public void increaseMaxHealth(int amt)
    {
        maxHealth += amt;
        heal(amt);
    }

    public void setHealth(int h)
    {
        health = h;
    }
}
