using System;
using UnityEngine;

public class ActionTile : Tile
{
    protected enum Tiletype { WATER, INSECT, BIRD, BEE, TAK }

    [SerializeField] protected Tiletype type;
    protected ActionTileObject actionTileObject;

    protected override void Start()
    {
        base.Start();
        if (type == Tiletype.BIRD)
        {
            PlaceBlock(tilePrefabs.Bird);
        }
        else if (type == Tiletype.INSECT)
        {
            PlaceBlock(tilePrefabs.Insect);
        }
        else if (type == Tiletype.WATER)
        {
            PlaceBlock(tilePrefabs.Water);
        }
        else if (type == Tiletype.BEE)
        {
            PlaceBlock(tilePrefabs.BeeHive);
        }
        else if (type == Tiletype.TAK)
        {
            PlaceBlock(tilePrefabs.Tak);
        }

        actionTileObject = TileObject.GetComponent<ActionTileObject>();
    }

    private void OnDisable()
    {
        // Hide all the things again.
        if (TileObject != null)
        {
            TileObject.SetActive(false);
        }
    }

    public override void PerformTileAction(InputManager.PlayerActions action)
    {
        if(action == InputManager.PlayerActions.SHOO_ANIMAL)
        {
            actionTileObject.TriggerTileObject();
        }
    }

    public override void OnTileEnter()
    {
        if (type == Tiletype.BEE
            || type == Tiletype.TAK
            || type == Tiletype.BIRD)
        {
            actionTileObject.OnTileEnter();
        }
    }

    public override void OnTileExit()
    {
        if (type == Tiletype.BEE
            || type == Tiletype.TAK
            || type == Tiletype.BIRD)
        {
            actionTileObject.OnTileExit();
        }
    }
}
