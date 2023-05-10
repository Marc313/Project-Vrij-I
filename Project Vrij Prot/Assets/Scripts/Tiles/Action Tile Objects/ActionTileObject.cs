using UnityEngine;

public abstract class ActionTileObject : MonoBehaviour
{
    public abstract void TriggerTileObject();
    public abstract void UpdateRelationBars();
    public virtual void OnTileEnter() { }
    public virtual void OnTileExit() { }

    protected bool isObjectDestroyed;
}