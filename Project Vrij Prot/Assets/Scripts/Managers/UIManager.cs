using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Canvas OverlayCanvas;
    public Canvas CutsceneCanvas;

    public Text tutorialText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateTutorialText("Hold space on the brown tiles to build a tree");
        //UpdateTutorialText("Press Enter to collect the water");
    }

    private void OnEnable()
    {
        GameManager.PhaseChange += UpdateTextByPhase;
    }
    private void OnDisable()
    {
        GameManager.PhaseChange -= UpdateTextByPhase;
    }

    public void ShowCutsceneUI()
    {
        CutsceneCanvas.gameObject.SetActive(true);
        OverlayCanvas.gameObject.SetActive(false);
    }

    public void HideCutsceneUI()
    {
        CutsceneCanvas.gameObject.SetActive(false);
        OverlayCanvas.gameObject.SetActive(true);
    }

    public void UpdateTutorialText(string text)
    {
        tutorialText.text = text;
    }

    // Move to Tutorial Text Class?
    public void UpdateTextByPhase(GameManager.GamePhase phase)
    {
        if(phase == GameManager.GamePhase.Birds)
        {
            UpdateTutorialText("Press Enter to scare the birds away");
        }
    }
}
