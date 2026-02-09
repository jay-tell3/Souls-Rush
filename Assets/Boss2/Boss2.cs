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
    public ParticleSystem par5;
    public bool inPhase2 = false;
    private int attack;
    public BruningAttack b;
    public GameObject HitBx;
    public GameObject Fire;
    public bool inAn;
    public GameObject myPrefab;
    public GamerManger gameManger;
    public GameObject doors;
    public ParticleSystem stomp;
    private AudioManger audioManger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss2Hp.value = 100;
        audioManger = GameObject.Find("AudioManger").GetComponent<AudioManger>();
        audioManger.audioSource.clip = audioManger.audioClip3;
        audioManger.audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (boss2Hp.value < 1 && !inPhase2)
        {
            audioManger.audioSource.clip = audioManger.audioClip4;
            audioManger.audioSource.Play();
            inAn = true;
            attacking = false;
            radiusCheck.radius = 4;
            animator.SetTrigger("phase2");
            par2.Play();
            par3.Play();
            par5.Play();
            phase2 = true;
            animator.SetBool("phase2B", true);

            boss2Hp.value = 100;
            Invoke("PhaseChange", 5f);
            inPhase2 = true;
        } else if (boss2Hp.value < 1 && inPhase2)
        {
            GamerManger.Instance.BossK();
            audioManger.audioSource.clip = audioManger.audioClip1;
            audioManger.audioSource.Play();
            par5.Stop();
            Instantiate(myPrefab, transform.position, transform.rotation);
            doors.SetActive(false);
            gameObject.SetActive(false);

        }

        if (animator.GetBool("inRange") == false && !phase2 && !attacking)
        {
            transform.Translate(Vector3.forward * 8 * Time.deltaTime);
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
                attack = Random.Range(8, 9);

                if (attack < 5 && !attacking)
                {
                    Vector3 direction = target.position - transform.position;
                    transform.rotation = Quaternion.LookRotation(direction);
                    attacking = true;
                    animator.SetTrigger("attack");
                    animator.SetBool("attacking", true);

                    animator.SetFloat("Blend", attack);
                    Invoke("Noattack", 3.6f);
                    if (inPhase2)
                    {

                        HitBx.SetActive(true);
                        par4.Play();
                        par.Play();
                        if (attack == 0)
                        {
                            Invoke("FireT", 2f);

                        }
                    }
                }
                else if (inPhase2)
                {
                    attack = Random.Range(1, 2);
                    if (attack == 0)
                    {
                         animator.SetTrigger("BruningAttack"); 
                        
                        b.A1();
                        attacking = true;
                        Invoke("Noattack", 3f);
                    }
                    else
                    {
                        
                           
                        animator.SetTrigger("Stomp");

                        Invoke("Stomp", 0.8f);
                        attacking = true;
                        Invoke("Noattack", 3f);
                    }
                }

            }

        }
    }
    void Noattack()
    {
        HitBx.SetActive(false);
        par4.Clear();
        par4.Stop();
        par.Clear();
        par.Stop();
        animator.SetBool("attacking", false);
        attacking = false;
    }
    void Stomp()
    {
    stomp.Play();
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && attacking) // Replace "Player" with your desired tag
        {
            Debug.Log("ouch");
            if(!inPhase2)
            {
            player.playerHp.value -= 5;
            }
            else
            {
            player.playerHp.value -= 10;
            }
           
        }

    }
    void PhaseChange()
    {
        inAn = false;
        animator.SetBool("phase2B", false);
        phase2 = false;
    }
    void FireT()
    {
        Vector3 direction = target.position - transform.position;
        Instantiate(Fire, transform.position, transform.rotation = Quaternion.LookRotation(direction));
    }
}
