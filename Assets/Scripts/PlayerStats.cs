using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    private static float knockBackMultiplier = 1;
    private static int additionalHealth = 0;
    private static float speedMultiplier = 1;
    private static float damageMultiplier = 1;
    private static float defence;
    private static float attackSpeed;
    
    public int getAdditionalHealth() {
        return additionalHealth;
    }
    public float getSpeedMultiplier() {
        return speedMultiplier;
    }
    public float getDamageMultiplier() {
        return damageMultiplier;
    }
    public float getKnockBackMultiplier() 
    {
        return knockBackMultiplier;
    }
    public void HealthBoost ()
    {
        additionalHealth++;
    }
    public void KnockBoost()
    {
        knockBackMultiplier += .25f;
    }
    public void speedBoost() 
    {
        speedMultiplier += .25f;
    }
    public void damageBoost() 
    {
        damageMultiplier += .2f;
    }
    
}
