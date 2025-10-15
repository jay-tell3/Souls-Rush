using UnityEngine;

public class RadiusCheck : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector
    public float radius = 2f;
    public float radiuss = 2f;
    public bool close;
    private bool farRange;
    public Animator animator;
    public Boss1 boss1;
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) <= radius)
        {

            animator.SetBool("inRange", true);
            close = true;

        }
        else 
        {
                animator.SetBool("inRange", false);
                close = false;
        }
    }
}
