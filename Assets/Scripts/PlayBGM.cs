using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public bool playOnAwake = true;
    public AudioClip toPlay;

    private void Start()
    {
        if (playOnAwake)
        {
            play();
        }
    }

    public void play()
    {
        BGMPlayer.playBGM(toPlay);

    }
}
