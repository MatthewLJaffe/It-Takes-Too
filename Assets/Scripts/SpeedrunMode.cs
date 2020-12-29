using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunMode : MonoBehaviour
{
    public static bool speedrunMode = true;

    public void toggleSpeedrunMode(bool active)
    {
        speedrunMode = active;
    }
}
