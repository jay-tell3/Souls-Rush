
using System.Collections;

using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   //variable place
    public Rigidbody rb;
    public GameObject cam;
    public GameObject targetCam, playerCam;
    public Animator animator;
    public Sword SwordPar;
    public ParticleSystem fire;
    public Slider playerHp;
    public GamerManger gamerManger;
    private float ver, horiz;
    public bool rolling;
    public bool Frolling;
    public bool Brolling;
    public bool Rrolling;
    public bool Lrolling;
    private float attack;
    public bool attacking;
    private bool rollMo=false;
    private bool roolMo;
    private bool rollCoolDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHp = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    /*
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 5);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, -5);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.linearVelocity = new Vector3(5, rb.linearVelocity.y, rb.linearVelocity.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.linearVelocity = new Vector3(-5, rb.linearVelocity.y, rb.linearVelocity.z);
            }

        }
    */
    void Update()
    {
       

        if(playerHp.value < 1)
        {
            SceneManager.LoadScene(0);
        }
        Vector3 moveDirection = Vector3.zero;

        ver = Input.GetAxis("Vertical");
        horiz = Input.GetAxis("Horizontal");
        animator.SetFloat("ver", ver);
        animator.SetFloat("horiz", horiz);


        if (ver > 0 && !rolling && !attacking)
        {
            moveDirection += cam.transform.forward;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
            //transform.Rotate(Vector3.up, cam.transform.rotation.y);
        }
        if (ver < 0 && !rolling && !attacking)
        {
            moveDirection -= cam.transform.forward;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
        }

        if (horiz > 0 && !rolling && !attacking)
        {
            moveDirection += cam.transform.right;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);

        }
        if (horiz < 0 && !rolling && !attacking)
        {
            moveDirection -= cam.transform.right;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
        }

        if (cam == playerCam)
        {
            playerCam.SetActive(true);
            targetCam.SetActive(false);
        }
        else
        {
            playerCam.SetActive(false);
            targetCam.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            if (cam == playerCam)
            {
                cam = targetCam;
            }
            else if (cam == targetCam)
            {
                cam = playerCam;
            }
        }

        if (Input.GetKey(KeyCode.E) && ver > 0 && !rolling && !attacking && !rollCoolDown)
        {
            rollCoolDown = true;

            rolling = true;
            rollMo = true;
            roolMo = false;
            //StartCoroutine(MoveRoll());

            animator.SetTrigger("Roll");
            Invoke("NoRoll", 0.75f);
            Invoke("RollCoolDown", 1f);
        }
        if (Input.GetKey(KeyCode.E) && ver < 0 && !rolling && !attacking && !rollCoolDown)
        {
            rollCoolDown = true;
            Brolling = true;
            rolling = true;
            rollMo = true;
            roolMo = false;
            animator.SetTrigger("Roll");
            Invoke("NoRoll", 0.75f);
            Invoke("RollCoolDown", 1f);
        }
        if (Input.GetKey(KeyCode.E) && horiz > 0 && !rolling && !attacking  && !rollCoolDown)
        {
            rollCoolDown = true;
            rolling = true;
            rollMo = true;
            roolMo = false;
            //StartCoroutine(MoveRoll());
            animator.SetTrigger("sideRoll");
            transform.Rotate(0, 90, 0);
            Invoke("NoRoll", 0.75f);
            Invoke("RollCoolDown", 1f);
        }
        if (Input.GetKey(KeyCode.E) && horiz < 0 && !rolling && !attacking  && !rollCoolDown)
        {
            rollCoolDown = true;
            rolling = true;
            rollMo = true;
            roolMo = false;
            animator.SetTrigger("sideRoll");
            transform.Rotate(0, -90, 0);
            Invoke("NoRoll", 0.75f);
            Invoke("RollCoolDown", 1f);
        }

        if (rolling && !Brolling )
        {
            transform.Translate(Vector3.forward * 7 * Time.deltaTime);
        }
        if (rolling && Brolling )
        {
            transform.Translate(Vector3.forward * -7 * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0) && !attacking && !rolling)
        {
            attacking = true;
            fire.Play();
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
            attack = Random.Range(0, 3);
            animator.SetFloat("attack", attack);
            animator.SetTrigger("Attack");
            Invoke("NoAttacking", 0.5f);
        }
        if (roolMo == false)
        {
            roolMo = true;
            Debug.Log("mo");
           gameObject.tag = "roll";
            Invoke("Noroll", 0.4f);
        }
       
        moveDirection.Normalize(); // To prevent faster diagonal movement
        moveDirection *= 5f; // Speed

        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);

    }
    void Noroll()
    {
        gameObject.tag = "Player";
        rollMo = false;
       // roolMo = false;
    }
    public void NoRoll()
    {
        rolling = false;
        Frolling = false;
        Brolling = false;
        Rrolling = false;
        Lrolling = false;

    }
    void RollCoolDown()
    {
        rollCoolDown = false;
    }
    public void NoAttacking()
    {
        attacking = false;
        fire.Stop();
    }
    public IEnumerator MoveRoll()
    {
        // while (rolling)
        //transform.Translate(Vector3.forward * 10 * Time.deltaTime); 
        transform.Translate(Vector3.forward * 5);
        yield return null;

    }
    public void Hurt()
    {
        playerHp.value -= 20;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Brun")) // Replace "Player" with your desired tag
        {

            Hurt();
        }
    }
}