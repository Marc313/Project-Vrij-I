using UnityEngine;

public static class UnityClassExtensions
{
    public static Vector3Int ToVector3Int(this Vector3 vector)
    {
        return new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
    }

    public static void SetYPosition(this Transform transform, float value)
    {
        transform.position = new Vector3(transform.position.x, value, transform.position.z);
    }
}

