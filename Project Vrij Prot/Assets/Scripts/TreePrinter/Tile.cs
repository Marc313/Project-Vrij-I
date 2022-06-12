using UnityEngine;

public class Tile : MonoBehaviour
{
    protected TileColors tileColors;
    protected TilePrefabs tilePrefabs;
    protected SpriteRenderer sprite;
    protected GameObject TileObject;
    // MAKE THIS ENUM LATER
    public bool isGreen;

    protected bool CanPlaceBlocks;

    protected virtual void Awake()
    {
        GetSpriteRendererComponent();
    }

    public void GetSpriteRendererComponent()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        tileColors = TileSettings.Instance.tileColors;
        tilePrefabs = TileSettings.Instance.tilePrefabs;
        UpdateTileColor();
    }

    public void UpdateTileColor()
    {
        if (isGreen)
        {
            sprite.color = tileColors.Green;
        }
        else if (!isGreen)
        {
            sprite.color = tileColors.Red;
        }
    }

    public void PlaceBlock(GameObject BlockPrefab)
    {
        CanPlaceBlocks = false;
        Vector3 blockPos = transform.position.ToVector3Int() + 0.5f * Vector3.up;
        TileObject = Instantiate(BlockPrefab, blockPos, Quaternion.identity);
    }

    public virtual void PerformTileAction(InputManager.PlayerActions action)
    {

    }
}
