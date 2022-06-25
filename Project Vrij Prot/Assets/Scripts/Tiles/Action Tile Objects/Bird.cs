public class Bird : ActionTileObject
{
    public void BullyBird()
    {
        gameObject.SetActive(false);
        isObjectDestroyed = true;
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
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.01f);
    }

    public override void OnTileExit()
    {
        if (isObjectDestroyed) return;
        // When the Bird is not destroyed
        RelationBarManager.Instance.IncreaseOmgevingScore(0.01f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(-0.01f);
    }
}