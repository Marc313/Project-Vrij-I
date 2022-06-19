using System;
using UnityEngine;

public class PathMovement : MovingObject
{
    public float treeGrowDistance;
    [HideInInspector] public WaypointSet currentWaypointSet;

    private int currentWaypointIndex;
    private Vector3Int currentClosestTile;
    private Vector3 targetPos;        // The position of the waypoint the indicator is currently traveling to.

    private void Update()
    {
        MoveToTargetPos();
        UpdateClosestTile();
    }

    private void UpdateClosestTile()
    {
        Vector3Int closestTile = ClosestTile();
        if (closestTile != currentClosestTile)
        {
            GridManager.Instance.OnTileExit(currentClosestTile);
            GridManager.Instance.OnTileEnter(closestTile);
            currentClosestTile = closestTile;
        }
    }

    public void StartMovement()
    {
        currentWaypointIndex = 0;

        SetPositionToStartWaypoint();

        currentSpeed = moveSpeed;
        DecideNextPoint();
    }

    public void StartNewLayer(WaypointSet newSet)
    {
        SetCurrentWaypointSet(newSet);
        currentWaypointIndex = 0;

        SetPositionToStartWaypoint();
        DecideNextPoint();
    }

    private void MoveToTargetPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPos);

        if(distance < 0.01f)
        {
            DecideNextPoint();
        }
    }

    public Vector3Int ClosestTile()
    {
        return (transform.position).ToVector3Int();
    }

    private void DecideNextPoint()
    {
        // Laatste is waypoint.Length - 1, dus een na laatste is waypoints.Lenght - 2
        if (currentWaypointIndex < currentWaypointSet.waypoints.Length - 1)     // Als de volgende waypoint niet de laatste is
        {
            NextWaypoint();
        } else
        {
            GameManager.Instance.MoveToNextLayer();
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;

        Vector3Int nextWaypoint = currentWaypointSet.waypoints[currentWaypointIndex].position.ToVector3Int();

        targetPos = new Vector3(nextWaypoint.x, CurrentHeight(), nextWaypoint.z);
    }

    /**
     * Sets the position of the player to the position of the first waypoint in the current set. 
     * Sets the height to the current height of the game
     */
    private void SetPositionToStartWaypoint()
    {
        Vector3 firstWaypointPos = currentWaypointSet.waypoints[0].position;
        transform.position = new Vector3(firstWaypointPos.x, CurrentHeight(), firstWaypointPos.z);
    }

    public void PauseMovement()
    {
        FreezeObject();
    }

    public void ContinueMovement()
    {
        UnfreezeObject();
    }

    public void SetCurrentWaypointSet(WaypointSet newSet)
    {
        currentWaypointSet = newSet;
    }

    private float CurrentHeight()
    {
        return GameManager.Instance.CurrentHeight + 0.01f;
    }
}
