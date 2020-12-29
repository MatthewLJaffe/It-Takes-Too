using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeWeapon : Weapon
{
    public string attackTrigger = "attack";

    protected Animator animator;

    public override void attack()
    {
        animator.SetTrigger(attackTrigger);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag(opponentTag))
    //    {
    //        Health otherHealth = collision.GetComponent<Health>();

    //        if (otherHealth != null)
    //        {
    //            otherHealth.damage(damage);
    //        }
    //    }
    //}
}
