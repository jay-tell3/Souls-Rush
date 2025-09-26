using UnityEngine;

public class boss1 : MonoBehaviour
{
    public RadiusCheck radiusCheck;
    public Transform target;
    public Animator animator;
    void Update()
    {
        radiusCheck = GetComponent<RadiusCheck>();
        if (!radiusCheck.close) 
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
        }
        else
        {
            animator.SetTrigger("A1");
        }
      
        
        
        
        
        
        
        
        
        
        /*if (target != null)
        {
            transform.LookAt(target.position, Vector3.up); // Makes this object look at the target
        }*/
        
    }

}
