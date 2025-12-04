
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
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Tor",3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inTor)
        {


            if (tp && !attcking && !inTor)
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
        else
        {
            Tor();
            
        }
       

    }
    void Tor()
    {
        inTor = true;
        animator.SetTrigger("tornado");
        transform.position = new Vector3(0, -0.8177662f, 0);
        
        Invoke("Notor",5);
    }
    
    void Tp()
    {
        if (!attcking) {
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
        switch (Random.Range(1,5))
        {
            case 1:
                transform.position = target.position + new Vector3(1, 0, 0);
                break;
            case 2:
                transform.position = target.position + new Vector3(-1, 0, 0);
                break;
            case 3:
                transform.position = target.position + new Vector3(0, 0,1);
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
       
        
        Invoke("NoAttck",1.50f);
    }
    void Notor()
    {
        animator.ResetTrigger("tornado");
        animator.SetTrigger("NoTor");
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
        for (int i = 0; i < 10; i++)
        {
            Instantiate(lighting, new Vector3(Random.Range(-10, 11), -0.8177662f, Random.Range(-10, 11)), Quaternion.identity);


        }
    }
}
