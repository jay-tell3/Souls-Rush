using UnityEngine;

public class RadiusCheck : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector
    public float radius = 2f;
    public bool close;
    public Animator animator;
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) <= radius)
        {
            animator.SetBool("inRange",true);
            close = true;
            Debug.Log("Target is within the radius!");
        }
        else
        {
            animator.SetBool("inRange", false);
            close = false;
        }
    }
}
