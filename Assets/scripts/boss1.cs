using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public RadiusCheck radiusCheck;
    public Transform target;
    public Animator animator;
    public ParticleSystem ps;
    public bool attacking;
    private bool Farattacking = false;
    private int attack = 99;
    private float farRange = 10;
    private bool InfarRange;
    public Slider boss1Hp;
    private bool grounded;
    public Collider armCollider;
    public Player player;
    public GameObject myPrefab;
    public bool roar = false;
    public bool pickedAttack;
    public ParticleSystem wave;
    public ParticleSystem arm;
    private void Start()
    {
        animator.SetBool("hasRoared", false);
    }
    void Update()
    {
        if (boss1Hp.value < 1)
        {
            Instantiate(myPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("boss1 run"))
        {
            armCollider.enabled = false;
        }
        else
        {
            armCollider.enabled = true;
        }
        radiusCheck = GetComponent<RadiusCheck>();
        // ps = GetComponentInChildren<ParticleSystem>();

        if (!radiusCheck.close && !animator.GetCurrentAnimatorStateInfo(0).IsName("BossA3"))
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
                Vector3 direction = target.position - transform.position;
                // radiusCheck.animator.SetBool("inRange", false);

                if (roar == false)
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                    animator.SetTrigger("A1");
                    roar = true;

                    Debug.Log("attacked");
                    Invoke("StartAttack", 6f);
                    Invoke("Wave", 2);
                    Invoke("NoWave", 4);
                }



                /*/ Check if the direction is valid (non-zero)
                if (direction != Vector3.zero)
                {
                    // Apply LookRotation constrained to the Y-axis
                    transform.rotation = Quaternion.LookRotation(direction);
                }*/



            }
            else
            {
                if (attack == 1 && !pickedAttack)
                {
                    pickedAttack = true;
                    Invoke("Par", 0.5f);
                    Invoke("NoPar", 1f);
                    Invoke("NoAttacking", 4f);


                }
                else if (attack == 0 && !pickedAttack)
                {
                    pickedAttack = true;
                    arm.Play();
                    Invoke("NoAttacking", 3.5f);


                }
                else if (attack == 2 && !pickedAttack)
                {
                    pickedAttack = true;
                    Debug.Log("jumping");
                    arm.Play();
                    StartCoroutine("JumpAttack");
                }
            }


        }


        if (Vector3.Distance(transform.position, target.position) <= farRange)
        {

            InfarRange = true;
            //Debug.Log("far range") ;
        }
        else
        {

            InfarRange = false;
        }
        if (Farattacking == false && InfarRange)
        {
            Farattacking = true;
            // Invoke("FarAttack",Random.Range(1,25));
        }
        /*if (target != null)
        {
            transform.LookAt(target.position, Vector3.up); // Makes this object look at the target
        }*/

    }

    IEnumerator JumpAttack()
    {
        float jumpTime = 0;
        while (jumpTime <= 5f)
        {
            radiusCheck.close = true;
            radiusCheck.animator.SetBool("inRange", true);
            jumpTime += Time.deltaTime;
            if (!grounded)
            {
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            }
            yield return null;
        }
        attacking = false;
        NoAttacking();
        yield return null;
    }
    void FarAttack()
    {
        Farattacking = true;
        attacking = true;
        radiusCheck.animator.SetBool("inRange", true);
        animator.SetTrigger("A1");
        attack = 2;
        animator.SetFloat("attack", attack);
        StartCoroutine("JumpAttack");
    }
    void StartAttack()
    {
        //if (!roar)
        {
           
            animator.SetBool("hasRoared", true);
            Debug.Log("is attacking");
            // Get the direction to the target
            Vector3 direction = target.position - transform.position;
            // Zero out the Y component to constrain rotation to the Y-axis
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
            attacking = true;
            radiusCheck.animator.SetBool("inRange", false);
            animator.SetTrigger("A1");
            attack = Random.Range(0, 3);
            animator.SetFloat("attack", attack);
            roar = true;
        }
    }
    void Wave()
    {
        wave.Play();
    }
    void NoWave()
    {
        wave.Stop();
    }
    public void Par()
    { ps.Play(); }
    public void NoPar()
    { ps.Stop(); }
    public void NoAttacking()
    {
        arm.Stop();
        pickedAttack = false;
        Debug.Log("no attack");
           animator.SetBool("hasRoared", false);
        roar = false;
        attacking = false;

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && attacking) // Replace "Player" with your desired tag
        {
            Debug.Log("Player entered the trigger!");
            // Perform actions specific to the Player entering
            player.playerHp.value -= 10;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;

        }

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            grounded = false;

        }
    }


}
