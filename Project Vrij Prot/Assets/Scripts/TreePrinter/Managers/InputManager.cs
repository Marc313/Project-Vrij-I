using UnityEngine;

public class InputManager : Singleton<InputManager>
{
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
            GridManager.Instance.OnPlayerAction(playerClosestTile, KeyCode.Space);
        } 
        // Pressing Enter: Shoo animals away
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            GridManager.Instance.OnPlayerAction(playerClosestTile, KeyCode.Return);
        }
    }
}