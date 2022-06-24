using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource music1;
    public AudioSource music2;
    private AudioSource currentBGM;

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

        if (currentBGM.isPlaying) currentBGM.UnPause();
        else currentBGM.Play();
    }

    public void PauseBGM()
    {
        currentBGM.Pause();
    }

    public void LowerPitch(float difference)
    {
        currentBGM.pitch -= difference;
    }

    public void SwitchSong()
    {
        if (music1 == null || music2 == null) return;

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
    }
}