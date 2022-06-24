using UnityEngine;

public class Tile : MonoBehaviour
{
    protected enum TileColorType { NOBLOCK, TREE, BLAADJE, BLOEMETJE, BEE}

    [SerializeField] protected TileColorType colorType;
    protected TileColors tileColors;
    protected TilePrefabs tilePrefabs;
    protected SpriteRenderer sprite;
    protected GameObject TileObject;

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
        switch (colorType)
        {
            case TileColorType.TREE:
                sprite.color = tileColors.Tree;
                break;
            case TileColorType.BLAADJE:
                sprite.color = tileColors.Blaadje;
                break;
            case TileColorType.BLOEMETJE:
                sprite.color = tileColors.Bloemetje;
                break;
            case TileColorType.BEE:
                sprite.color = tileColors.Bee;
                break;
            case TileColorType.NOBLOCK:
            default:
                sprite.color = tileColors.NoBlock;
                break;
        }
    }

    public virtual void PlaceBlock(GameObject BlockPrefab)
    {
        CanPlaceBlocks = false;
        Vector3 blockPos = transform.position.ToVector3Int() + 0.5f * Vector3.up;

        int random = Random.Range(0, 4);
        Quaternion randomDirection = Quaternion.Euler(0, random * 90, 0);
        TileObject = Instantiate(BlockPrefab, blockPos, randomDirection);
    }

    public virtual void PerformTileAction(InputManager.PlayerActions action) { }
    public virtual void OnTileEnter() { }
    public virtual void OnTileExit() { }
}
