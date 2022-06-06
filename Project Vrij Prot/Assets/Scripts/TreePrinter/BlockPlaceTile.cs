using UnityEngine;

public class BlockPlaceTile : Tile
{
    public GameObject TreeBlockPrefab;

    private void Start()
    {
        CanPlaceBlocks = true;
    }

    public override void PerformTileAction(KeyCode pressedKey)
    {
        if (!CanPlaceBlocks) return;

        if(pressedKey == KeyCode.Space)
        {
            PlaceBlock(TreeBlockPrefab);
        }
    }
}
