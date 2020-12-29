using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public static BGMPlayer instance;
    public static AudioSource bgmAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            bgmAudio = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void playBGM(AudioClip clip)
    {
        bgmAudio.clip = clip;
        bgmAudio.Play();
    }
}
