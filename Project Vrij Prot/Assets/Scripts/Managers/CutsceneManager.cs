using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManager : Singleton<CutsceneManager>
{
    public VideoPlayer IntroCutscene;
    public bool PlayIntroCutscene = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(PlayIntroCutscene && IntroCutscene != null)
        {
            PlayCutscene(IntroCutscene);
        }
    }

    /*private void OnEnable()
    {
        GameManager.PhaseChange += PlayCutsceneOnPhaseEnd;
    }
    private void OnDisable()
    {
        GameManager.PhaseChange -= PlayCutsceneOnPhaseEnd;
    }*/

    public void OnCutsceneStart()
    {
        Debug.Log("Cutscene Start");
        UIManager.Instance.ShowCutsceneUI();        // Show the Cutscene Canvas and Hide other Canvas
        GameManager.Instance.PauseGame();           // Pause the playermovement
    }

    public void OnCutsceneEnd()
    {
        Debug.Log("Cutscene End");
        UIManager.Instance.HideCutsceneUI();
        GameManager.Instance.UnpauseGame();
    }

    public void PlayCutscene(VideoPlayer cutscene)
    {
        OnCutsceneStart();
        cutscene.Play();
        Invoke(nameof(OnCutsceneEnd), (float)IntroCutscene.length);
    }

    /*public void PlayCutsceneOnPhaseEnd(GameManager.GamePhase newPhase)
    {
        if(newPhase == GameManager.GamePhase.Birds)
        {
            PlayCutscene(Cutscene);
        }
    }*/
}
