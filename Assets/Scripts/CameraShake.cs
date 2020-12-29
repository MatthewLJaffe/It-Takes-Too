using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Shake
{
    // Start is called before the first frame update
    void Start()
    {
        toShake = Player.mainCamera.transform;
    }

}
