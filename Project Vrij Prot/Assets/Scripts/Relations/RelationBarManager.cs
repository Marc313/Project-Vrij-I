using System;
using UnityEngine;

public class RelationBarManager : Singleton<RelationBarManager>
{
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
        omgevingScore += value;
        omgevingBar.UpdateSliderValue(omgevingScore);
    }

    public void IncreaseBoomMachtScore(float value)
    {
        boomMachtScore += value;
        boomMachtBar.UpdateSliderValue(boomMachtScore);
    }

    public void IncreaseBoomHealthScore(float value)
    {
        boomHealthScore += value;
        boomHealthBar.UpdateSliderValue(boomHealthScore);
    }

    public void IncreaseCultScore(float value)
    {
        cultScore += value;
        cultBar.UpdateSliderValue(cultScore);
    }
}