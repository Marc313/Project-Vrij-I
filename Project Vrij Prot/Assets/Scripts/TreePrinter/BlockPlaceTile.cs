using UnityEngine;

public class BlockPlaceTile : Tile
{
    protected override void Start()
    {
        base.Start();
        CanPlaceBlocks = true;
    }

    public override void PerformTileAction(InputManager.PlayerActions action)
    {
        if (!CanPlaceBlocks) return;

        if (action == InputManager.PlayerActions.PLACE_TREE)
        {
            PlaceBlock(tilePrefabs.Treeblock);
        }
        else if (action == InputManager.PlayerActions.PLACE_BLAADJE)
        {
            PlaceBlock(tilePrefabs.BlaadjeBlock);
        } 
        else if (action == InputManager.PlayerActions.PLACE_BLOEMETJE)
        {
            PlaceBlock(tilePrefabs.BloemetjeBlock);
        }
    }
}
