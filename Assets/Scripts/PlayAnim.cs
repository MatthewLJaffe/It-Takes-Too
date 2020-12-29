using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public Animator anim;
    public string triggerToSet;

    public void play()
    {
        anim.SetTrigger(triggerToSet);
    }
}
