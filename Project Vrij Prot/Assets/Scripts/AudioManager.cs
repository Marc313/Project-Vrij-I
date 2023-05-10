using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource music1;
    public AudioSource music2;
    private AudioSource currentBGM;

    private float gameplayPitch;
    private float pitchMultiplier = 1f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentBGM = music1;
        StartBGM();
    }

    private void Update()
    {
        if (currentBGM.clip.length - currentBGM.time < 0.1f)
        {
            SwitchSong();
        }
    }

    public void StartBGM()
    {
        if (currentBGM == null) return;

        gameplayPitch = currentBGM.pitch;
        if (currentBGM.isPlaying) currentBGM.UnPause();
        else currentBGM.Play();
    }

    public void PauseBGM()
    {
        currentBGM.Pause();
    }

    public void LowerPitch(float difference)
    {
        currentBGM.pitch -= difference * pitchMultiplier;
        gameplayPitch = currentBGM.pitch;
    }

    public void SetPitch(float newPitch)
    {
        currentBGM.pitch = newPitch;
    }

    public void ReturnPitchToGameplayPitch()
    {
        currentBGM.pitch = gameplayPitch;
    }

    public void SetPitchMultiplier(float newValue)
    {
        pitchMultiplier = newValue;
    }

    public void SwitchSong()
    {
        if (music1 == null || music2 == null) return;

        float currentPitch = currentBGM.pitch;

        Debug.Log("Switch");
        if (currentBGM.Equals(music1))
        {
            currentBGM.Stop();
            currentBGM = music2;
            currentBGM.Play();
        } 
        else
        {
            currentBGM.Stop();
            currentBGM = music1;
            currentBGM.Play();
        }

        currentBGM.pitch = currentPitch;
    }

    public void StopMusic()
    {
        currentBGM.Stop();
    }
}