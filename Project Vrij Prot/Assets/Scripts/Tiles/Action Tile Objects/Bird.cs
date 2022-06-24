using UnityEngine;

public class Bird : ActionTileObject
{
    public void BullyBird()
    {
        gameObject.SetActive(false);
    }

    public override void TriggerTileObject()
    {
        UpdateRelationBars();
        BullyBird();
        AudioManager.Instance.LowerPitch(0.001f);
    }

    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseOmgevingScore(-0.03f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(0.01f);
    }
}