using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : SmoothFollow
{
    // Start is called before the first frame update
    void Start()
    {
        dest = Player.instance.transform;
    }
}
