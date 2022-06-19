using UnityEngine;

public class Water : ActionTileObject
{
    public void CollectWater()
    {
        gameObject.SetActive(false);
    }

    public override void TriggerTileObject()
    {
        UpdateRelationBars();
        CollectWater();
    }

    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.05f);
    }
}