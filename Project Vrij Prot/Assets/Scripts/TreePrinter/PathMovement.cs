using UnityEngine;

public class PathMovement : MovingObject
{
    public float treeGrowDistance;
    public Transform[] waypoints;
    //[HideInInspector] public bool isActive = true;

    private int currentWaypoint;
    private Vector3 oldPos;
    private Vector3 targetPos;        // The position of the waypoint the indicator is currently traveling to.
    private bool isAscending = true;

    public Vector3Int ClosestTile()
    {
        return (transform.position).ToVector3Int();
    }

    private void DecideNextPoint()
    {
        if (isAscending)
        {
            // Laatste is waypoint.Length - 1, dus een na laatste is waypoints.Lenght - 2
            if (currentWaypoint < waypoints.Length - 2)
            {
                MoveToNextWaypoint(true);
            }
            else if (currentWaypoint == waypoints.Length - 2)
            {
                MoveToNextWaypoint(false);
            }
            else
            {
                isAscending = false;
                MoveToPreviousWaypoint(true);
            }
        } 
        else if (!isAscending)
        {
            if (currentWaypoint > 1)
            {
                MoveToPreviousWaypoint(true);
            } 
            else if (currentWaypoint == 1)
            {
                MoveToPreviousWaypoint(false);
            }
            else
            {
                //GameManager.Instance.MoveToNextLayer();
                isAscending = true;
                MoveToNextWaypoint(true);
            }
        }
    }

    private void MoveToNextWaypoint(bool continueAutomatically)
    {
        Vector3Int previousWaypoint = waypoints[currentWaypoint].position.ToVector3Int();
        Vector3Int nextWaypoint = waypoints[currentWaypoint + 1].position.ToVector3Int();

        oldPos = new Vector3(previousWaypoint.x, CurrentHeight(), previousWaypoint.z);
        targetPos = new Vector3(nextWaypoint.x, CurrentHeight(), nextWaypoint.z);
        
        if(continueAutomatically)
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => DecideNextPoint()));
        } else
        {
            StartCoroutine(MoveCharacterRoutine(oldPos, targetPos, () => GameManager.Instance.MoveToNextLayer()));
        }

        currentWaypoint++;
    }

    private void MoveToPreviousWaypoint(bool continueAutomatically)
    {
        Vector3Int oldWaypoint = waypoints[currentWaypoint].position.ToVector3Int();
        Vector3Int prevWaypoint = waypoints[currentWaypoint - 1].position.ToVector3Int();

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
    }

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

    public void ContinueMovement()
    {
        UnfreezeObject();
        StopAllCoroutines();

        Vector3Int currentPosition = transform.position.ToVector3Int();
        Vector3 oldPosition = new Vector3(currentPosition.x, CurrentHeight(), currentPosition.z);
        StartCoroutine(MoveCharacterRoutine(oldPosition, targetPos, () => DecideNextPoint()));
    }

    private float CurrentHeight()
    {
        return GameManager.Instance.CurrentHeight + 0.01f;
    }
}
