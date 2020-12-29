using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    public void increaseHealth(int amt)
    {
        Player.instance.GetComponent<Health>().increaseMaxHealth(amt);
    }
}
