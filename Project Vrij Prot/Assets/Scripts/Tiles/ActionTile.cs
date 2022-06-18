using UnityEngine;

public class ActionTile : Tile
{
    private enum Tiletype { WATER, BIRD }

    [SerializeField] private Tiletype type;

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
        TileObject.SetActive(false);
    }

    public void CollectWater()
    {
        TileObject.SetActive(false);
        RelationBarManager.Instance.IncreaseBoomHealthScore(0.05f);
    }

    public void BullyBird()
    {
        TileObject.SetActive(false);
        RelationBarManager.Instance.IncreaseOmgevingScore(-0.03f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(0.01f);
    }

    public override void PerformTileAction(InputManager.PlayerActions action)
    {
        if(action == InputManager.PlayerActions.SHOO_ANIMAL)
        {
            if (type == Tiletype.WATER)
            {
                CollectWater();
            }
            else if (type == Tiletype.BIRD)
            {
                BullyBird();
            }
        }
    }
}
