// Currently Unused Script
/*using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject TreeBlockPrefab;

    public float treeGrowDistance = .2f;

    void Update()
    {
        HandleMoveInput();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            transform.position += Vector3.up;
        }
    }

    private void HandleMoveInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.position += (horizontalInput * Vector3.right + verticalInput * Vector3.forward) * moveSpeed * Time.deltaTime;

        Vector3Int closestSquare = (transform.position - Vector3.up).ToVector3Int();
        if(!GridManager.IsTileOccupied(closestSquare))
        {
            float distance = Vector3.Distance(transform.position - Vector3.up, closestSquare);
            if (distance < treeGrowDistance)
            {
                Instantiate(TreeBlockPrefab, closestSquare, Quaternion.identity);
                //GridManager.AddTile(closestSquare, GridManager.TreeLayer.TREE);
            }
        }
    }


}
*/