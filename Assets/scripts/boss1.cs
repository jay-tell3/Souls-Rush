using System.Collections;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    public RadiusCheck radiusCheck;
    public Transform target;
    public Animator animator;
    private ParticleSystem ps;
    private bool attacking;
    private int attack;
    void Update()
    {
        radiusCheck = GetComponent<RadiusCheck>();
        ps = GetComponentInChildren<ParticleSystem>();
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
            if (attacking == false)
            {

                attacking = true;
                radiusCheck.animator.SetBool("inRange", false);
                animator.SetTrigger("A1");
                attack = Random.Range(0, 2);
                animator.SetFloat("attack", attack);
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
                if (attack == 1)
                {
                    Invoke("Par", 0.5f);
                    Invoke("NoPar", 1f);
                    Invoke("NoAttacking", 4f);
                }
                else
                {
                    Invoke("NoAttacking", 3.5f);
                }
                
                
            }
        
        }
        
        /*if (target != null)
        {
            transform.LookAt(target.position, Vector3.up); // Makes this object look at the target
        }*/
        
    }

    /*IEnumerator Attack()
    {
        
    }*/
    public void Par()
    { ps.Play(); }
    public void NoPar()
    { ps.Stop(); }
    public void NoAttacking()
    {
        attacking = false;
        
    }

}
