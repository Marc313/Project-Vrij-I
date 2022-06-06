using UnityEngine;

public class FlowerTrigger : MonoBehaviour
{
    public GameObject FlowerPrefab;
    private bool isOccupied;

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return;

        isOccupied = true;
        int randomDegrees = 90 * (Random.Range(0, 3) + 1);
        Quaternion randomRotation = Quaternion.Euler(0, randomDegrees, 0);
        Instantiate(FlowerPrefab, transform.position, randomRotation, transform);
    }
}
