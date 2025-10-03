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
    private float farRange = 10;
    private bool InfarRange;
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
            if (direction != Vector3.zero && !attacking)
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
                attack = Random.Range(0, 3);
                animator.SetFloat("attack", attack);
                // Get the direction to the target
                Vector3 direction = target.position - transform.position;

                // Zero out the Y component to constrain rotation to the Y-axis
                direction.y = 0;

                /*/ Check if the direction is valid (non-zero)
                if (direction != Vector3.zero)
                {
                    // Apply LookRotation constrained to the Y-axis
                    transform.rotation = Quaternion.LookRotation(direction);
                }*/
                if (attack == 1)
                {
                    Invoke("Par", 0.5f);
                    Invoke("NoPar", 1f);
                    Invoke("NoAttacking", 4f);
                }
                else if (attack == 0)
                {
                    Invoke("NoAttacking", 3.5f);
                }
                else if (attack == 2)
                {
                    StartCoroutine("JumpAttack");
                }
                

            }
        
        }
        if (Vector3.Distance(transform.position, target.position) <= farRange)
        {

            InfarRange = true;
            Debug.Log("far range") ;
        }
        else
        {

            InfarRange = false;
        }
        if (attacking == false && InfarRange)
        {
            attacking = true;
            radiusCheck.animator.SetBool("inRange", true);
            animator.SetTrigger("A1");
            attack = 2;
            animator.SetFloat("attack", attack);
            StartCoroutine("JumpAttack");
        }
            /*if (target != null)
            {
                transform.LookAt(target.position, Vector3.up); // Makes this object look at the target
            }*/

        }

    IEnumerator JumpAttack()
    {
        float jumpTime = 0;
        float jumpStrong= 60;
        while (jumpTime <= 3.5f)
        {
            radiusCheck.animator.SetBool("inRange", true);
            jumpTime += Time.deltaTime;
            transform.Translate(Vector3.forward * 6 * Time.deltaTime);
            transform.Translate(Vector3.up * jumpStrong * Time.deltaTime);
            if (jumpStrong >= 1)
            {
                jumpStrong--;
            }
            yield return null;
        }
        attacking = false;
        yield return null;
    }

    public void Par()
    { ps.Play(); }
    public void NoPar()
    { ps.Stop(); }
    public void NoAttacking()
    {
        attacking = false;
        
    }

}
