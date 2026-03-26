
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public bool tried;
    public ParticleSystem deBuff;
    private int rNum;
    public GameObject torG;
    public Player player;
    public ParticleSystem lRing;
    public ParticleSystem lRing2;
    public Slider boss3Hp;
    public CapsuleCollider hittBox;
    private bool tiredE;
    public GameObject myPrefab;
    private AudioManger audioManger;
    public CapsuleCollider capsuleCollidera;
    public CapsuleCollider capsuleCollidera2;
    public AudioSource audioSource;
    public GameObject win;
    public GameObject mainMenuButton2;
    public bool isActive = false;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;
    public AudioClip audioClip6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss3Hp.value = 100;
        isActive = true;
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
        /*
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleB2"))
        {
         
            capsuleCollidera.enabled = false;
            capsuleCollidera2.enabled = false;
        }
        */
        if (boss3Hp.value < 1)
        {
            GamerManger.Instance.BossK();
            audioManger.audioSource.clip = audioManger.audioClip5;
            audioManger.audioSource.Play();
            Instantiate(myPrefab, transform.position, transform.rotation);
            lRing.Stop();
            isActive = false;
            if (Main.start2 == true)
            { 
             win.SetActive(true);
                EventSystem.current.SetSelectedGameObject(mainMenuButton2);
                Cursor.lockState = CursorLockMode.None;

            }
                gameObject.SetActive(false);
            
        }
        if (change)
        {
            Debug.Log("Change");
            Invoke("SpecislAttck", 10);
            change = false;
        }
        if(clones >= 2)//yfhffjghj
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
                Invoke("AttackHitBox",0.5f);
                tpTime = 0;
                Debug.Log("fffffff");
                Attck();

            }
        }
        


    }
    void Tor()
    {
        audioSource.clip = audioClip6;
        audioSource.Play();
        inTor = true;
        animator.SetTrigger("tornado");
        transform.position = new Vector3(0, -0.8177662f, 0);
      Invoke("TorPar2",1);
        Invoke("Notor", 7);
    }
    void TorPar2()
    {
        torG.SetActive(true);
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
            audioSource.clip = audioClip2;
            audioSource.Play();
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
        capsuleCollidera.enabled = false;
        capsuleCollidera2.enabled = false;
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
        //Instantiate(lighting, new Vector3(target.position.x, -0.8177662f, target.position.z), Quaternion.identity);

    }
    void Eacho()
    {
        audioSource.clip = audioClip3;
        audioSource.Play();
        walk = true;
        tpFX.Play();
        lRing.Stop();
        lRing2.Play();
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
        lRing2.Clear();
        lRing2.Stop();
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
        audioSource.clip = audioClip4;
        audioSource.Play();
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
        audioSource.clip = audioClip5;
        audioSource.Play();
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

    void AttackHitBox()
    {
        capsuleCollidera.enabled = true;
        capsuleCollidera2.enabled = true;
    }

}
