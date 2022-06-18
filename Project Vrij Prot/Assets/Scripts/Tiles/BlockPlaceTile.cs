using UnityEngine;

public class BlockPlaceTile : Tile
{
    private enum TileType { NOBLOCK, TREE, BLAADJE, BLOEMETJE}

    [SerializeField] private TileType type;

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
            CheckTilePlacement(TileType.TREE);
        }
        else if (action == InputManager.PlayerActions.PLACE_BLAADJE)
        {
            PlaceBlock(tilePrefabs.BlaadjeBlock);
            CheckTilePlacement(TileType.BLAADJE);

        }
        else if (action == InputManager.PlayerActions.PLACE_BLOEMETJE)
        {
            PlaceBlock(tilePrefabs.BloemetjeBlock);
            CheckTilePlacement(TileType.BLOEMETJE);
        }
    }

    /**
     * Checks if a block is placed on the correct tile.
     * Updates the relation bars accordingly.
     */
    private void CheckTilePlacement(TileType placedBlockType)
    {
        if (type != placedBlockType)
        {
            RelationBarManager.Instance.IncreaseBoomHealthScore(-0.01f);
        } else
        {
            RelationBarManager.Instance.IncreaseBoomMachtScore(0.005f);
        }
    }
}
