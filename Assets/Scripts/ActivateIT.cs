using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIT : MonoBehaviour
{
    public void activate()
    {
        Player.IT.gameObject.SetActive(true);
    }
}
