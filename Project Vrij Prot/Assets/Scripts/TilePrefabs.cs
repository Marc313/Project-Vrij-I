using UnityEngine;

[CreateAssetMenu(fileName = "TilePrefabs", menuName = "Tiles/Prefabs")]
public class TilePrefabs : ScriptableObject
{
    [Header("Blocks")]
    public GameObject Treeblock;

    [Header("Action Tiles")]
    public GameObject Bird;
    public GameObject Water;

}