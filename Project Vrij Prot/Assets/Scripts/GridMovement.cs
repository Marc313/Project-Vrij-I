// Currently Unused Script
/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public GameObject TreeBlockPrefab;
    public Camera cam;

    private void OnEnable()
    {
        GameManager.LayerChange += MoveUp;
    }
    private void OnDisable()
    {
        GameManager.LayerChange -= MoveUp;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleBlockPlaceInput();
    }

    private void HandleBlockPlaceInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3Int currentPos = transform.position.ToVector3Int();
            if (!GridManager.IsTileOccupied(currentPos))
            {
                Instantiate(TreeBlockPrefab, currentPos + new Vector3(0, .5f, 0), Quaternion.identity);
                //GridManager.AddTile(currentPos, GridManager.TreeLayer.TREE);
            }
        }
    }

    private void HandleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= Vector3.right;
        }
    }

    private void MoveUp()
    {
        transform.position += Vector3.up;
        cam.transform.position += Vector3.up;
    }
}
*/