using UnityEngine.Video;

public class CutsceneManager : Singleton<CutsceneManager>
{
    public CutscenePrefabs cutscenes;
    public bool PlayIntroCutscene = true;
    public VideoPlayer player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(PlayIntroCutscene && cutscenes.IntroCutscene != null)
        {
            PlayCutscene(cutscenes.IntroCutscene);
        }
    }

    public void OnCutsceneStart()
    {
        UIManager.Instance.ShowCutsceneUI();        // Show the Cutscene Canvas and Hide other Canvas
        GameManager.Instance.PauseGame();           // Pause the playermovement
    }

    public void OnCutsceneEnd()
    {
        UIManager.Instance.HideCutsceneUI();
        GameManager.Instance.UnpauseGame();
        AudioManager.Instance.ReturnPitchToGameplayPitch();
    }

    public void PlayCutscene(VideoClip cutscene)
    {
        player.clip = cutscene;
        OnCutsceneStart();
        player.Play();
        Invoke(nameof(OnCutsceneEnd), (float)cutscene.length + .8f);
    }

    public void PlayCultFleeBees ()
    {
        if (cutscenes.CultFleeBees != null)
        {
            PlayCutscene(cutscenes.CultFleeBees);
        }
    }

    public void PlayCultFleeBranch()
    {
        if (cutscenes.CultFleeBranch != null)
        {
            PlayCutscene(cutscenes.CultFleeBranch);
        }
    }

    public void PlayCultEnding()
    {
        if (cutscenes.CultEinde != null)
        {
            AudioManager.Instance.SetPitch(.5f);
            PlayCutscene(cutscenes.CultEinde);
        }
    }

    public void PlayMachtEnding()
    {
        if (cutscenes.MachtEinde != null)
        {
            AudioManager.Instance.SetPitch(.75f);
            PlayCutscene(cutscenes.MachtEinde);
        }
    }

    public void PlayNatureEnding()
    {
        if (cutscenes.NatureEinde != null)
        {
            AudioManager.Instance.SetPitch(1.005f);
            PlayCutscene(cutscenes.NatureEinde);
        }
    }
}
