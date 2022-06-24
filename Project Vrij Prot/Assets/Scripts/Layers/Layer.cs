using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Layer : MonoBehaviour
{
    public float printerSpeed = 10;
    public WaypointSet waypoints;
    public bool IncreaseHeightAfterLayer;
    public UnityEvent AfterLayer;

    private Dictionary<Vector3Int, Tile> tileReferences;

    private Tile[] tiles;

    private void Awake()
    {
        tiles = GetComponentsInChildren<Tile>();

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
        if (!tileReferences.ContainsKey(tilePos))
        {
            tileReferences.Add(tilePos, tile);
        }
    }

    public void OnTileEnter(Vector3Int tilePosition)
    {
        if (tileReferences != null
            && tileReferences.ContainsKey(tilePosition))
        {
            tileReferences[tilePosition].OnTileEnter();
        }
    }

    public void OnTileExit(Vector3Int tilePosition)
    {
        if (tileReferences != null 
            && tileReferences.ContainsKey(tilePosition))
        {
            tileReferences[tilePosition].OnTileExit();
        }
    }

    public void OnPlayerAction(Vector3Int tilePosition, InputManager.PlayerActions action)
    {
        if (tileReferences != null && tileReferences.ContainsKey(tilePosition))
        {
            tileReferences[tilePosition].PerformTileAction(action);
        }
    }
}
