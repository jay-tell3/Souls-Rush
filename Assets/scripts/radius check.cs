using UnityEngine;

public class RadiusCheck : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector
    public float radius = 5f;
    public bool close;
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= radius)
        {
            close = true;
            Debug.Log("Target is within the radius!");
        }
        else
        {
            close = false;
        }
    }
}
