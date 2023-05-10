using UnityEngine;

public class Tak : MashingTileObject
{
    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseCultScore(-1f);
        RelationBarManager.Instance.IncreaseBoomHealthScore(-0.2f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(-0.15f);
    }
}