using UnityEngine;

public class BeeHive : MashingTileObject
{
    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseCultScore(-0.25f);
        RelationBarManager.Instance.IncreaseOmgevingScore(-0.1f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(0.1f);
    }

    public override void OnTileExit()
    {
        base.OnTileExit();
        if (!isObjectDestroyed)
        {
            // When the BeeHive is not destroyed
            RelationBarManager.Instance.IncreaseOmgevingScore(0.1f);
            RelationBarManager.Instance.IncreaseBoomMachtScore(-0.1f);
        }
    }
}