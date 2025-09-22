using UnityEngine;

public class boss1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public Transform target; // Assign the target object in the Inspector
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        // Get the direction to the target
        Vector3 direction = target.position - transform.position;

        // Zero out the Y component to constrain rotation to the Y-axis
        direction.y = 0;

        // Check if the direction is valid (non-zero)
        if (direction != Vector3.zero)
        {
            // Apply LookRotation constrained to the Y-axis
            transform.rotation = Quaternion.LookRotation(direction);
        }
        /*if (target != null)
        {
            transform.LookAt(target.position, Vector3.up); // Makes this object look at the target
        }*/
        
    }

}
