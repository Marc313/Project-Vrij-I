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

    public override void OnTileExit()
    {
        if (type != TileType.NOBLOCK && TileObject == null)
        {
            AddIncorrectScores();
        }
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

    private void AddCorrectScores()
    {
        RelationBarManager.Instance.IncreaseBoomMachtScore(0.004f);
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.003f);

    }

    private void AddIncorrectScores()
    {
        RelationBarManager.Instance.IncreaseBoomHealthScore(-0.003f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(-0.001f);
    }

    /**
     * Checks if a block is placed on the correct tile.
     * Updates the relation bars accordingly.
     */
    private void CheckTilePlacement(TileType placedBlockType)
    {
        if (type != placedBlockType)
        {
            AddIncorrectScores();
        } else
        {
            AddCorrectScores();
        }
    }
}
