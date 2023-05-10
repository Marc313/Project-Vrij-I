using UnityEngine;

[CreateAssetMenu(fileName = "TilePrefabs", menuName = "Tiles/Prefabs")]
public class TilePrefabs : ScriptableObject
{
    [Header("Blocks")]
    public GameObject Treeblock;
    public GameObject BlaadjeBlock;
    public GameObject BloemetjeBlock;

    [Header("Action Tiles")]
    public GameObject Bird;
    public GameObject Insect;
    public GameObject Water;
    public GameObject BeeHive;
    public GameObject Tak;
}