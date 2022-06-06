using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public Layer[] layers;
    private int currentLayer;

    private void Awake()
    {
        Instance = this;
    }

    //public enum TileType { TREE, BIRD }
    //private static Dictionary<Vector3Int, Tile> grid = new Dictionary<Vector3Int, Tile>();

    /*public static void AddTile(Vector3Int v, Tile layer)
    {
        grid.Add(v, layer);
    }

    public static Tile RemoveTile(Vector3Int v)
    {
        Tile temp = grid[v];

        if(grid.ContainsKey(v))
        {
            grid.Remove(v);
        }

        return temp;
    }

    public static Tile GetTile(Vector3Int v)
    {
        if (!grid.ContainsKey(v)) return null;
        return grid[v];
    }

    public static bool IsTileOccupied(Vector3Int v)
    {
        return grid.ContainsKey(v);
    }

    public static bool IsBirdTile(Vector3Int v)
    {
        return grid.ContainsKey(v) && grid[v].GetType() == typeof(ActionTile);
    }*/

    public void OnPlayerAction(Vector3Int tilePosition, KeyCode pressedKey)
    {
        layers = GameManager.Instance.Layers;
        currentLayer = GameManager.currentLayerIndex;

        layers[currentLayer]?.OnPlayerAction(tilePosition, pressedKey);
    }
}

/*using System.Collections.Generic;
using UnityEngine;

public static class GridManager
{
    public enum TileType { TREE, BIRD }
    private static Dictionary<Vector3Int, TileType> grid = new Dictionary<Vector3Int, TileType>();

    public static void AddTile(Vector3Int v, TileType type)
    {
        grid.Add(v, type);
    }

    public static TileType RemoveTile(Vector3Int v)
    {
        TileType temp = grid[v];

        if (grid.ContainsKey(v))
        {
            grid.Remove(v);
        }

        return temp;
    }

    public static bool IsTileOccupied(Vector3Int v)
    {
        return grid.ContainsKey(v);
    }

    public static bool IsBirdTile(Vector3Int v)
    {
        return grid.ContainsKey(v) && grid[v] == TileType.BIRD;
    }
}*/