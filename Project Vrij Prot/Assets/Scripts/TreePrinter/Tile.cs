using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileColors tileColors;
    protected SpriteRenderer sprite;
    protected GameObject TileObject;
    // MAKE THIS ENUM LATER
    public bool isGreen;

    protected bool CanPlaceBlocks;

    private void Awake()
    {
        GetSpriteRendererComponent();
    }

    public void GetSpriteRendererComponent()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
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

    public virtual void PerformTileAction(KeyCode pressedKey)
    {

    }
}
