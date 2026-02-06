
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Boss3 : MonoBehaviour
{
    private bool tp = true;
    public Transform target;
    public Animator animator;
    private float TPnum;
    private float NOnum = 1;
    private bool change = true;
    private int attcks ;
    private bool attcking;
    private int tpTime;
    public ParticleSystem tpFX;
    public ParticleSystem tpFX2;
    private bool inTor;
    public GameObject lighting;
    private float lightingTime;
    private bool walk;
    private bool clone = true;
    public GameObject Clone;
    public int clones = 0;
    public ParticleSystem TorPar;
    private bool lightingAttack;
    public GameObject eSword;
    private bool tried;
    public ParticleSystem deBuff;
    private int rNum;
    public GameObject torG;
    public Player player;
    public ParticleSystem lRing;
    public Slider boss3Hp;
    public CapsuleCollider hittBox;
    private bool tiredE;
    public GameObject myPrefab;
    private AudioManger audioManger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss3Hp.value = 100;
        lRing.Play();
        audioManger = GameObject.Find("AudioManger").GetComponent<AudioManger>();
        audioManger.audioSource.clip = audioManger.audioClip5;
        audioManger.audioSource.Play();
        //Invoke("Tor", 1);
        // Invoke("Eacho",5);

        //Invoke("LightingAttack",5);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss3Hp.value < 1)
        {
            audioManger.audioSource.clip = audioManger.audioClip5;
            audioManger.audioSource.Play();
            Instantiate(myPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
            
        }
        if (change)
        {
            Debug.Log("Change");
            Invoke("SpecislAttck", 10);
            change = false;
        }
        if(clones >= 10)
        {
            clones = 0;
        }
        if (walk)
        {
            transform.Translate(Vector3.forward * 17 * Time.deltaTime);
            transform.Rotate(0, -76 * Time.deltaTime, 0);
            if (clone)
            {
                clone = false;
                Instantiate(Clone,transform.position, transform.rotation);
                clones += 1;
                Invoke("NoClone",0.2f);
            }
            tpFX.Stop();
            tpFX2.Stop();
            tiredE = true;
            Invoke("NoEacho",10);
        }
        if (!inTor || !walk || !lightingAttack ||!tried)
        {


            if (tp && !attcking && !inTor && !walk && !lightingAttack && !tried)
            {
                ++tpTime;
                tp = false;
                tpFX.Stop();
                tpFX2.Stop();
                Invoke("Tp", 0.5f);
            }
            if (tpTime == 5)
            {
                attcking = true;
                tpTime = 0;
                Debug.Log("fffffff");
                Attck();

            }
        }
        


    }
    void Tor()
    {
        inTor = true;
        animator.SetTrigger("tornado");
        transform.position = new Vector3(0, -0.8177662f, 0);
        torG.SetActive(true);
        Invoke("Notor", 5);
    }

    void Tp()
    {
        if (!attcking)
        {
            TPnum = Random.Range(0, 5);
            while (TPnum == NOnum)
            {
                TPnum = Random.Range(0, 5);
            }
            NOnum = TPnum;
            if(!lightingAttack||!inTor || !tried)
            {
             tpFX.Play();
            }
            
           // tpFX2.Play();


            animator.SetFloat("TpP", TPnum);
            animator.SetTrigger("Tp");

            

            transform.position = new Vector3(Random.Range(-10, 11), -0.8177662f, Random.Range(-10, 11));
            Vector3 direction = target.position - transform.position;

            // Zero out the Y component to constrain rotation to the Y-axis
            direction.y = 0;

            // Check if the direction is valid (non-zero)
            if (direction != Vector3.zero)
            {
                //  Apply LookRotation constrained to the Y-axis
                transform.rotation = Quaternion.LookRotation(direction);
            }
            tp = true;
        }
    }

    void Attck()
    {

        attcks = Random.Range(0, 4);
        animator.SetFloat("attcks", attcks);
        switch (Random.Range(1, 5))
        {
            case 1:
                transform.position = target.position + new Vector3(1, 0, 0);
                break;
            case 2:
                transform.position = target.position + new Vector3(-1, 0, 0);
                break;
            case 3:
                transform.position = target.position + new Vector3(0, 0, 1);
                break;
            case 4:
                transform.position = target.position + new Vector3(0, 0, -1);
                break;

        }

        Vector3 direction = target.position - transform.position;

        // Zero out the Y component to constrain rotation to the Y-axis
        direction.y = 0;

        // Check if the direction is valid (non-zero)
        if (direction != Vector3.zero)
        {
            //  Apply LookRotation constrained to the Y-axis
            transform.rotation = Quaternion.LookRotation(direction);
        }

        animator.SetTrigger("Attack");


        Invoke("NoAttck", 1.50f);
    }
    void Notor()
    {
        animator.ResetTrigger("tornado");
        animator.SetTrigger("NoTor");
        torG.SetActive(false);     
        inTor = false;
        Tried();
    }
    void NoAttck()
    {

        tpTime = 0;
        attcking = false;
        tp = true;
    }
    void Lighting()
    {

        lightingTime = 0;
        for (int i = 0; i < 50; i++)
        {

            Invoke("LightingSpawn", lightingTime);
            lightingTime += 0.1f;
        }
    }
    void LightingSpawn()
    {
        Instantiate(lighting, new Vector3(Random.Range(-10, 11), -0.8177662f, Random.Range(-10, 11)), Quaternion.identity);
        Instantiate(lighting, new Vector3(target.position.x, -0.8177662f, target.position.z), Quaternion.identity);

    }
    void Eacho()
    {
        walk = true;
        tpFX.Play();
        lRing.Stop();
        //tpFX2.Play();






        transform.position = new Vector3(13, -0.8177662f, 0);
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0));
        animator.SetTrigger("Walk");
        

    }
    void NoEacho()
    {   
        walk = false;
        animator.SetTrigger("NoWalk");
        lRing.Play();
        if(tiredE)
        {
            tiredE = false;
         Tried();
        }
        
    }
    void NoClone()
    {
        clone = true;
        animator.SetTrigger("Walk");
    }
    void LightingAttack()
    {
        lightingAttack = true;
        eSword.SetActive(true);
        //B
        attcks = Random.Range(0, 4);
        animator.SetFloat("attcks", attcks);
        transform.position = new Vector3(0, -0.8177662f, 0);

        Vector3 direction = target.position - transform.position;

        // Zero out the Y component to constrain rotation to the Y-axis
        direction.y = 0;

        // Check if the direction is valid (non-zero)
        if (direction != Vector3.zero)
        {
            //  Apply LookRotation constrained to the Y-axis
            transform.rotation = Quaternion.LookRotation(direction);
        }
        //E
        animator.SetTrigger("Lighting");
        Invoke("Lighting", 1.8f);
        Invoke("NoLighting", 10);
    }
    void NoLighting()
    {
        eSword.SetActive(false);
        animator.SetTrigger("NoLighting");
        lightingAttack = false;
        Tried();
        
    }
    void Tried()
    {
        tried = true;
        tpFX.Play();
        transform.position = new Vector3(0, -0.8177662f, 0);
        animator.SetTrigger("Tried");
        deBuff.Play();
        hittBox.enabled = true;
        
        Invoke("NoTried", 5);
    }
    void NoTried()
    {
        hittBox.enabled=false;
        tried = false;
        animator.SetTrigger("NoTried");
        deBuff.Stop();
        change = true;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && attcking) // Replace "Player" with your desired tag
        {
            Hitplayer();
           
        }

    }
    public void Hitplayer()
    {
    player.playerHp.value -= 10;
    }
    void SpecislAttck()
    {
       
        rNum = Random.Range(1, 4);
        if (rNum >= 3)
        {

            Eacho();
            
        }
        else if (rNum >= 2)
        {
            LightingAttack();
        }
        else 
        {
            Tor();
        }
    }


}
