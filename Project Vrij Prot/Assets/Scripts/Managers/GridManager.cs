using System;
using UnityEngine;

/** 
 * Used for passing signals from the player to a specific tile
 */
public class GridManager : Singleton<GridManager>
{
    private Layer currentLayer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentLayer = GameManager.Instance.Layers[0];
    }

    private void OnEnable()
    {
        GameManager.LayerChange += UpdateCurrentLayer;
    }

    private void OnDisable()
    {
        GameManager.LayerChange -= UpdateCurrentLayer;
    }

    public void OnTileEnter(Vector3Int tilePos)
    {
        currentLayer.OnTileEnter(tilePos);
    }

    public void OnTileExit(Vector3Int tilePos)
    {
        currentLayer.OnTileExit(tilePos);
    }

    public void OnPlayerAction(Vector3Int tilePosition, InputManager.PlayerActions action)
    {
        currentLayer.OnPlayerAction(tilePosition, action);
    }

    private void UpdateCurrentLayer()
    {
        currentLayer = GameManager.Instance.currentLayer;
    }
}