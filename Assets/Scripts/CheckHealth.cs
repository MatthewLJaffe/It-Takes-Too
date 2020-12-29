using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckHealth: MonoBehaviour
{
    public int healthToHave = 1;
    public UnityEvent OnHealthReached;

    private Health health;

    private void Start()
    {
        health = Player.instance.GetComponent<Health>();
    }



    public void check()
    {
        StartCoroutine(checkTheHealth());
    }

    private IEnumerator checkTheHealth()
    {
        while (health.CurrentHealth > healthToHave)
        {
            yield return null;
        }
        OnHealthReached.Invoke();

    }
}
