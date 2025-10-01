using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform targetObject; // The object to follow
    public Vector3 offset;         // Offset from the target object's position

    void Update()
    {
        if (targetObject != null)
        {
            // Update the position of this object relative to the target
            transform.position = targetObject.position + offset;
        }
    }
}
