using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public Animator animator;
    public RadiusCheck radiusCheck;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (animator.GetBool("inRange") == false)
        {
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            // Get the direction to the target
            Vector3 direction = target.position - transform.position;

            // Zero out the Y component to constrain rotation to the Y-axis
            direction.y = 0;

            // Check if the direction is valid (non-zero)
            if (direction != Vector3.zero)
            {
                //  Apply LookRotation constrained to the Y-axis
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
        else
        {
            animator.SetTrigger("attack");
            animator.SetFloat("Blend", Random.Range(0, 3));
             
        }
    }
}
