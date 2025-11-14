using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
{
    public Animator animator;
    public RadiusCheck radiusCheck;
    public Transform target;
    private bool attacking;
    public Slider boss2Hp;
    public Player player;
    private bool phase2;
    public ParticleSystem par;
    public ParticleSystem par2;
    public ParticleSystem par3;
    public ParticleSystem par4;
    private bool inPhase2 ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (boss2Hp.value < 1 && !inPhase2 )
        {
            radiusCheck.radius = 4;
            animator.SetTrigger("phase2");
            par2.Play();
            par3.Play();
            phase2 = true;
            animator.SetBool("phase2B",true);
            attacking = false;
            boss2Hp.value = 100;
            Invoke("PhaseChange",5f);
            inPhase2 = true;
        }

        if (animator.GetBool("inRange") == false && !phase2&& !attacking)
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
            if (!attacking && !phase2)
            { 
                animator.SetTrigger("attack");
                animator.SetBool("attacking",true);
                attacking = true;
                animator.SetFloat("Blend", Random.Range(0, 4));
                Invoke("Noattack", 3.6f);
                if (inPhase2)
                {
                    par4.Play();
                    par.Play();
                }
            }
        }
    }
    void Noattack ()
    {
        par4.Clear();
        par4.Stop();
        par.Clear();
        par.Stop();
        animator.SetBool("attacking", false);
        attacking = false;  
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && attacking) // Replace "Player" with your desired tag
        {
           
            player.playerHp.value -= 0;
        }

    }
    void PhaseChange()
    {
        animator.SetBool("phase2B", false);
        phase2 = false;
    }
}
