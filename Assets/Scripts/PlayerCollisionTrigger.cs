using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : CollisionTrigger
{
    private void Start()
    {
        source = Player.instance.transform;
    }
}
