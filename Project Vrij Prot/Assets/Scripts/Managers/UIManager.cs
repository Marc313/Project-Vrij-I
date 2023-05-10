using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Canvas OverlayCanvas;
    [SerializeField] private Canvas CutsceneCanvas;
    [SerializeField] private Canvas HealthEndingCanvas;

    [SerializeField] private Text tutorialText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateTutorialText("Press ENTER to collect water");
    }

    private void OnEnable() 
    {
        RelationBarManager.OnTreeDeath += ShowDeathScreen;
        RelationBarManager.OnTreeDeath += HideHUDCanvas;
    }
    private void OnDisable()
    {
        RelationBarManager.OnTreeDeath -= ShowDeathScreen;
        RelationBarManager.OnTreeDeath -= HideHUDCanvas;
    }

    public void ShowDeathScreen()
    {
        HealthEndingCanvas.gameObject.SetActive(true);
    }

    public void HideHUDCanvas()
    {
        OverlayCanvas.gameObject.SetActive(false);
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
}
