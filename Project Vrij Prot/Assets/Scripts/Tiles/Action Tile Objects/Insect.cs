public class Insect : ActionTileObject
{
    public void KillInsect()
    {
        gameObject.SetActive(false);
        isObjectDestroyed = true;
    }

    public override void TriggerTileObject()
    {
        UpdateRelationBars();
        KillInsect();
    }

    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.01f);
    }

    public override void OnTileExit()
    {
        if (isObjectDestroyed) return;

        RelationBarManager.Instance.IncreaseBoomHealthScore(-0.015f);
    }
}