using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HealthWeapon : MeleeWeapon
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player.instance.GetComponent<PlayerStats>().HealthBoost();
    }
}
