using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{ 
    public string weaponName;
    public string opponentTag = "Enemy";
    public int damage = 1;
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackFinish;

    public abstract void attack();

    public void attackStart()
    {
        OnAttackStart.Invoke();
    }

    public void attackFinish()
    {
        OnAttackFinish.Invoke();
    }
}
