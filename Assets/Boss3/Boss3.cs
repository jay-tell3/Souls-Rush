
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Boss3 : MonoBehaviour
{
    private bool tp = true;
    public Transform target;
    public Animator animator;
    private float TPnum;
    private float NOnum = 1;
    private bool change;
    private int attcks;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Invoke("Tor", 1);
       Invoke("Eacho",15);
       //Lighting();
    }

    // Update is called once per frame
    void Update()
    {
        if(clones >= 10)
        {
            clones = 0;
        }
        if (walk)
        {
            transform.Translate(Vector3.forward * 17 * Time.deltaTime);
            transform.Rotate(0, -70 * Time.deltaTime, 0);
            if (clone)
            {
                clone = false;
                Instantiate(Clone,transform.position, transform.rotation);
                clones += 1;
                Invoke("NoClone",0.2f);
            }
            tpFX.Stop();
            tpFX2.Stop();
            Invoke("NoEacho",10);
        }
        if (!inTor || !walk)
        {


            if (tp && !attcking && !inTor && !walk)
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
        TorPar.Play();
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
            tpFX.Play();
            tpFX2.Play();


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
        TorPar.Stop();
        inTor = false;
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
        for (int i = 0; i < 10; i++)
        {

            Invoke("LightingSpawn", lightingTime);
            lightingTime += 0.5f;
        }
    }
    void LightingSpawn()
    {
        Instantiate(lighting, new Vector3(Random.Range(-10, 11), -0.8177662f, Random.Range(-10, 11)), Quaternion.identity);

    }
    void Eacho()
    {
        walk = true;
        tpFX.Play();
        tpFX2.Play();






        transform.position = new Vector3(12, -0.8177662f, 0);
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0));
        animator.SetTrigger("Walk");
        

    }
    void NoEacho()
    {
        walk = false;
        animator.SetTrigger("NoWalk");
    }
    void NoClone()
    {
        clone = true;

    }
}
