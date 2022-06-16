using UnityEngine;

public class ActionTile : Tile
{
    public enum Tiletype { WATER, BIRD }

    public Tiletype type;

    protected override void Start()
    {
        base.Start();
        if (type == Tiletype.BIRD)
        {
            PlaceBlock(tilePrefabs.Bird);
        }
        else if (type == Tiletype.WATER)
        {
            PlaceBlock(tilePrefabs.Water);
        }
    }

    private void OnDisable()
    {
        // Hide all the things again.
        BullyBird();
    }

    public void BullyBird()
    {
        TileObject.SetActive(false);
        //StartCoroutine(nameof(MoveCharacterRoutine(BirdObject.pos)))
    }

    public override void PerformTileAction(InputManager.PlayerActions action)
    {
        if(action == InputManager.PlayerActions.SHOO_ANIMAL)
        {
            BullyBird();
        }
    }
}
