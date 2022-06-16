using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public enum PlayerActions { PLACE_TREE, PLACE_BLAADJE, PLACE_BLOEMETJE, COLLECT_WATER, SHOO_ANIMAL}

    private PathMovement playerMovement;

    private void Awake()
    {
        Instance = this;
        playerMovement = FindObjectOfType<PathMovement>();
    }

    private void Update()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        Vector3Int playerClosestTile = playerMovement.ClosestTile();

        // Holding Space: Placing Tree blocks
        if (Input.GetKey(KeyCode.Space))
        {
            GridManager.Instance.OnPlayerAction(playerClosestTile, PlayerActions.PLACE_TREE);
        }
        // Holding Shift: Placing Blaadje blocks
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            GridManager.Instance.OnPlayerAction(playerClosestTile, PlayerActions.PLACE_BLAADJE);
        }
        // Holding B: Placing Blaadje blocks
        else if (Input.GetKey(KeyCode.B))
        {
            GridManager.Instance.OnPlayerAction(playerClosestTile, PlayerActions.PLACE_BLOEMETJE);
        }
        // Pressing Enter: Shoo animals away
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            GridManager.Instance.OnPlayerAction(playerClosestTile, PlayerActions.SHOO_ANIMAL);
        }
    }
}