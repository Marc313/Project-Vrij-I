using UnityEngine;

public class TileSettings : Singleton<TileSettings>
{
    public TileColors tileColors;
    public TilePrefabs tilePrefabs;

    private void Awake()
    {
        Instance = this;
    }
}