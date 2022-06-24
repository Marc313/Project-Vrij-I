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
    }

    public void PlayCutscene(VideoClip cutscene)
    {
        player.clip = cutscene;
        OnCutsceneStart();
        player.Play();
        Invoke(nameof(OnCutsceneEnd), (float)cutscenes.IntroCutscene.length);
    }

    public void PlayCultEnding()
    {
        if (cutscenes.CultEinde != null)
        {
            PlayCutscene(cutscenes.CultEinde);
        }
    }

    public void PlayNatureEnding()
    {
        if (cutscenes.NatureEinde != null)
        {
            PlayCutscene(cutscenes.NatureEinde);
        }
    }

    public void PlayMachtEnding()
    {
        if (cutscenes.MachtEinde != null)
        {
            PlayCutscene(cutscenes.MachtEinde);
        }
    }
}
