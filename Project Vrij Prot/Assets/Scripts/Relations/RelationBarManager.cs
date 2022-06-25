using UnityEngine;

public class RelationBarManager : Singleton<RelationBarManager>
{
    public enum Ending { NATURE, CULTMACHT, BOOMMACHT}

    [SerializeField] public RelationBar omgevingBar;
    [SerializeField] public RelationBar boomMachtBar;
    [SerializeField] public RelationBar boomHealthBar;
    [SerializeField] public RelationBar cultBar;        // Invisiable at the start?

    private float omgevingScore = 0.5f;
    private float boomMachtScore = 0.1f;
    private float boomHealthScore = 0.1f;
    private float cultScore = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetSliderStartValues();
    }

    private void SetSliderStartValues()
    {
        omgevingBar.UpdateSliderValue(omgevingScore);
        boomMachtBar.UpdateSliderValue(boomMachtScore);
        boomHealthBar.UpdateSliderValue(boomHealthScore);
        cultBar.UpdateSliderValue(cultScore);
    }

    public void IncreaseOmgevingScore(float value)
    {
        omgevingScore = Mathf.Clamp01(value + omgevingScore);
        omgevingBar.UpdateSliderValue(omgevingScore);
    }

    public void IncreaseBoomMachtScore(float value)
    {
        boomMachtScore = Mathf.Clamp01(value + boomMachtScore);
        boomMachtBar.UpdateSliderValue(boomMachtScore);
    }

    public void IncreaseBoomHealthScore(float value)
    {
        boomHealthScore = Mathf.Clamp01(value + boomHealthScore);
        boomHealthBar.UpdateSliderValue(boomHealthScore);
    }

    public void IncreaseCultScore(float value)
    {
        cultScore = Mathf.Clamp01(value + cultScore);
        cultBar.UpdateSliderValue(cultScore);
    }

    public bool ShouldSkipTakLayer()
    {
        if (cultScore < .05f)
        {
            IncreaseCultScore(-1f);
            return true;
        } 
        else
        {
            return false;
        }
    }

    public bool isCultEnding()
    {
        if (cultScore < .05f)
        {
            return false;
        }

        return true;
    }

    public void SetCultbarActive(bool isActive)
    {
        cultBar.gameObject.SetActive(isActive);
    }

    public Ending DecideEnding()
    {
        if (boomMachtScore > omgevingScore)
        {
            return Ending.BOOMMACHT;
        }
        else
        {
            return Ending.NATURE;
        }
    }
}