using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimescale : MonoBehaviour
{
    public void set(int scale)
    {
        Time.timeScale = scale;
    }
}
