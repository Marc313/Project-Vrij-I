using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Work in progress
    public IEnumerator ZoomTowardsInSeconds(float oldOrthSize, float newOrthSize, float time)
    {
        cam.orthographicSize = oldOrthSize;

        float zoomDifference = Mathf.Abs(oldOrthSize - newOrthSize);
        float zoomSpeed = zoomDifference / time;
        float t = 0;

        /*while (t < time)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, currentSpeed * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        onDone?.Invoke();*/
        yield return null;
    }
}