using System.Collections;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    [HideInInspector] public float moveSpeed;
    protected float currentSpeed;

    private void OnDestroy()
    {
        StopCoroutine(nameof(MoveCharacterRoutine));
    }

    public void SetSpeed(float value)
    {
        moveSpeed = value;
    }

    public void FreezeObject()
    {
        currentSpeed = 0;
    }
    public void UnfreezeObject()
    {
        currentSpeed = moveSpeed;
    }

    public IEnumerator MoveCharacterRoutine(Vector3 oldPos, Vector3 targetPos, System.Action onDone = null)
    {
        transform.position = oldPos;

        float distance = Vector3.Distance(oldPos, targetPos);
        float time = distance / currentSpeed;
        float t = 0;

        while (t < time)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        onDone?.Invoke();
    }
}

