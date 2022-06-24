public class Insect : ActionTileObject
{
    public void KillInsect()
    {
        gameObject.SetActive(false);
    }

    public override void TriggerTileObject()
    {
        UpdateRelationBars();
        KillInsect();
    }

    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.015f);
    }
}