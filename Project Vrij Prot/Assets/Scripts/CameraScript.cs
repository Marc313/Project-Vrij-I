using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomTowardsTarget(Transform target)
    {
        // Standard Values;
        Vector3 oldPosition = cam.transform.position;
        Vector3 newPosition = CalculateNewCameraPos(oldPosition, target);

        float oldOrthSize = cam.orthographicSize;
        float newOrthSize = 10f;
        float time = .5f;

        StartCoroutine(ZoomTowardsInSeconds(oldPosition, newPosition, oldOrthSize, newOrthSize, time));
    }

    public Vector3 CalculateNewCameraPos(Vector3 oldCameraPosition, Transform target)
    {
        Vector3 targetPos = target.transform.position;
        Vector3 newCameraPos = target.transform.position + cam.transform.forward * -15; // Still keep a distance with the camera
        return newCameraPos;

        //cam.ScreenToWorldPoint(target.position);
        //return oldCameraPosition + Mathf.Cos(Quaternion.LookRotation(target.forward).)
        //return cam.transform.Translate(new Vector3(3f), cam.transform)

        /*Quaternion correctCameraRotation = cam.transform.rotation;
        cam.transform.LookAt(target);
        Quaternion cameraLookAtTarget = cam.transform.rotation;
        cam.transform.rotation = correctCameraRotation;
        float angle = Quaternion.Angle(correctCameraRotation, cameraLookAtTarget);
        float distanceToTarget = Vector3.Distance(cam.transform.position, target.transform.position);

        Vector3 moveDirection = cam.transform.right;

        // The distance with the position and the angle between the camera rotation and the camera rotation when looking at the object can be use to calculate the distance to the new camera position.
        float distanceToNewPosition = Mathf.Cos(angle) * distanceToTarget;
        Vector3 potentialCameraPos1 = cam.transform.position + distanceToNewPosition * moveDirection;
        Vector3 potentialCameraPos2 = cam.transform.position + distanceToNewPosition * -moveDirection;

        // Shortest distance between a camera and an object is when they align
        if (Vector3.Distance(target.position, potentialCameraPos1) < Vector3.Distance(target.position, potentialCameraPos2))
        {
            return potentialCameraPos1;
        }
        else
        {
            return potentialCameraPos2;
        }*/
    }

    // Work in progress
    public IEnumerator ZoomTowardsInSeconds(Vector3 oldPos, Vector3 targetPos, float oldOrthSize, float newOrthSize, float time, System.Action onDone = null)
    {
        cam.transform.position = oldPos;
        cam.orthographicSize = oldOrthSize;

        //float zoomDifference = newOrthSize - oldOrthSize;
        float passedTime = 0;

        while (passedTime < time)
        {
            // Move closer to the target OrthSize every frame
            cam.transform.position = Vector3.Lerp(oldPos, targetPos, passedTime/time);
            cam.orthographicSize = Mathf.Lerp(oldOrthSize, newOrthSize, passedTime/time);
            passedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Done");
        cam.transform.position = targetPos;
        cam.orthographicSize = newOrthSize;

        onDone?.Invoke();
    }
}