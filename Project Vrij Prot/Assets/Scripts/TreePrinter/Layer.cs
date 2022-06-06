using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Layer : MonoBehaviour
{
    public float printerSpeed = 10;
    public bool IncreaseHeightAfterLayer;
    public UnityEvent AfterLayer;

    private Dictionary<Vector3Int, Tile> tileReferences;

    private Tile[] tiles;


    // public BlockPlaceTile[] blockPlaceTiles;
    // public ActionTile[] actionTiles { get; private set; }

    private void Awake()
    {
        tiles = GetComponentsInChildren<Tile>();
        //blockPlaceTiles = GetComponentsInChildren<BlockPlaceTile>();
        //actionTiles = GetComponentsInChildren<ActionTile>();

        tileReferences = new Dictionary<Vector3Int, Tile>();
    }

    private void OnEnable()
    {
        GameManager.LayerChange += InvokeAfterLayerEvent;

        if (tileReferences.Count == 0 && tiles != null)
        {
            foreach (Tile tile in tiles)
            {
                AddTileReference(tile);
            }

            /*if (blockPlaceTiles != null)
            foreach (Tile tile in blockPlaceTiles)
            {
                AddTileReference(tile);
            }
            if (actionTiles != null)
            foreach (Tile tile in actionTiles)
            {
                AddTileReference(tile);
            }*/
        }
    }

    private void OnDisable()
    {
        GameManager.LayerChange -= InvokeAfterLayerEvent;
        if (IncreaseHeightAfterLayer)
        {
            GameManager.LayerChange -= GameManager.Instance.IncreaseCurrentHeight;
        }
    }

    private void InvokeAfterLayerEvent()
    {
        AfterLayer?.Invoke();
    }

    private void AddTileReference(Tile tile)
    {
        Vector3Int tilePos = tile.transform.position.ToVector3Int();
        tileReferences.Add(tilePos, tile);
    }

    public void OnPlayerAction(Vector3Int tilePosition, KeyCode pressedKey)
    {
        if (tileReferences != null && tileReferences[tilePosition] != null)
        {
            tileReferences[tilePosition].PerformTileAction(pressedKey);
        }
    }
}
