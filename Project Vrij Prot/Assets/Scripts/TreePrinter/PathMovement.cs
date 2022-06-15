using UnityEngine;

public class PathMovement : MovingObject
{
    public float treeGrowDistance;
    [HideInInspector] public WaypointSet currentWaypointSet;

    private int currentWaypointIndex;
    private Vector3 oldPos;
    private Vector3 targetPos;        // The position of the waypoint the indicator is currently traveling to.

    public Vector3Int ClosestTile()
    {
        return (transform.position).ToVector3Int();
    }

    private void DecideNextPoint()
    {
        // Laatste is waypoint.Length - 1, dus een na laatste is waypoints.Lenght - 2
        if (currentWaypointIndex < currentWaypointSet.waypoints.Length - 2)
        {
            MoveToNextWaypoint(true);
        }
        else if (currentWaypointIndex == currentWaypointSet.waypoints.Length - 2)
        {
            MoveToNextWaypoint(false);
        }
    }

    private void MoveToNextWaypoint(bool continueAutomatically)
    {
        Vector3Int previousWaypoint = currentWaypointSet.waypoints[currentWaypointIndex].position.ToVector3Int();
        Vector3Int nextWaypoint = currentWaypointSet.waypoints[currentWaypointIndex + 1].position.ToVector3Int();

        oldPos = new Vector3(previousWaypoint.x, CurrentHeight(), previousWaypoint.z);
        targetPos = new Vector3(nextWaypoint.x, CurrentHeight(), nextWaypoint.z);
        
        if(continueAutomatically)
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => DecideNextPoint()));
        } else
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => GameManager.Instance.MoveToNextLayer()));
        }

        currentWaypointIndex++;
    }

    /*private void MoveToPreviousWaypoint(bool continueAutomatically)
    {
        Vector3Int oldWaypoint = currentWaypointSet.waypoints[currentWaypoint].position.ToVector3Int();
        Vector3Int prevWaypoint = currentWaypointSet.waypoints[currentWaypoint - 1].position.ToVector3Int();

        Vector3 oldPos = new Vector3(oldWaypoint.x, CurrentHeight(), oldWaypoint.z);
        Vector3 targetPos = new Vector3(prevWaypoint.x, CurrentHeight(), prevWaypoint.z);

        if (continueAutomatically)
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => DecideNextPoint()));
        }
        else
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => GameManager.Instance.MoveToNextLayer()));
        }
        currentWaypoint--;
    }*/

    public void PauseMovement()
    {
        FreezeObject();
        StopAllCoroutines();
    }

    public void StartMovement()
    {
        currentSpeed = moveSpeed;
        DecideNextPoint();
    }

    public void SetCurrentWaypointSet(WaypointSet newSet)
    {
        currentWaypointSet = newSet;
        currentWaypointIndex = 0;
        transform.position = newSet.waypoints[0].position;
    }

    public void ContinueMovement()
    {
        UnfreezeObject();
        StopAllCoroutines();

        Vector3Int currentPosition = transform.position.ToVector3Int();
        Vector3 oldPosition = new Vector3(currentPosition.x, CurrentHeight(), currentPosition.z);
        //targetPos = currentWaypointSet.waypoints[currentWaypointIndex].position;
        StartCoroutine(MoveCharacterRoutine(oldPosition, targetPos, () => DecideNextPoint()));
    }

    private float CurrentHeight()
    {
        return GameManager.Instance.CurrentHeight + 0.01f;
    }
}
