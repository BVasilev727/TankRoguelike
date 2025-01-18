using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioClip musicOnStart;

    AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Play(musicOnStart,true);
    }

    AudioClip switchTo;

    public void Play(AudioClip clip, bool interupt = false)
    {
        if(interupt)
        {
            volume = 0.2f;
            musicSource.volume = volume;
            musicSource.clip = clip;
            musicSource.Play();
        }
        else
        {
            switchTo = clip;
            StartCoroutine(SmoothSwitchMusic());
        }
    }

    float volume;
    [SerializeField]
    float timeToSwitch;
    IEnumerator SmoothSwitchMusic()
    {
        volume = 0.2f;
        while (volume > 0f)
        {
            volume -=Time.deltaTime/timeToSwitch;
            if (volume < 0f)
            {
                musicSource.volume = volume;
                yield return new WaitForEndOfFrame();
            }
        }
        Play(switchTo,true);
    }
}
