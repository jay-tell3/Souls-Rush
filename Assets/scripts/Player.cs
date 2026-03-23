
using System.Collections;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
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
    public CamLock camLock;
    public ParticleSystem fire;
    public Slider playerHp;
    private int rollspeed =15000;
    //public GamerManger gamerManger;

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
    public Transform Spawnn;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public GameObject myPrefab;
    public float horizontal;
    public float vertical;
    private bool rollButton;
    private bool lockButton;
    private bool fireButton;
    private bool ultButton;
    public AudioSource source;
    private AudioManger audioManger;
    public GameObject sound;
    private GameObject soundClone;
    public GameObject menu;
    public bool wait;
    public static bool noHit = true;
    public EventSystem eventSystem;
    public GameObject notrophy;
    public GameObject mainMenuButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if ( Main.start == true)
        {
        CamLock.camUsed = false;
        noHit = true;
        notrophy.SetActive(false);
        }
        else
        {
            Debug.Log("trophy nooo");
            noHit = false;
            CamLock.camUsed = true;
            notrophy.SetActive(true);
        }


       

        playerHp = GetComponentInChildren<Slider>();
        if (GamerManger.BossDefeats == 0)
        {
            transform.position = Spawnn.position;
        }
        if (GamerManger.BossDefeats == 0 && GamerManger.Instance.Tp)
        {
            transform.position = Spawn1.position;
        }
        else if (GamerManger.BossDefeats == 1)
        {
            transform.position = Spawn2.position;
        }
        else if (GamerManger.BossDefeats == 2)
        {
            transform.position = Spawn3.position;
        }
        
        audioManger = GameObject.Find("AudioManger").GetComponent<AudioManger>();
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
       
        if (GamerManger.BossDefeats > 2 & noHit ==true)
        {
            Main.noHitTroph = true;
            Debug.Log("yes trophe");
        }

        if (GamerManger.BossDefeats > 2 & CamLock.camUsed  == false)
        {
            Main.noCamTroph = true;
            Debug.Log("yes cam trophe");
        }

        if (GamerManger.BossDefeats > 2 & Heal.noHeal == true)
        {
            Main.noHealTroph = true;
            Debug.Log("yes heal trophe");
        }

        if (ultButton)
        {
            menu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(mainMenuButton);
            Cursor.lockState = CursorLockMode.None;
        }
       
        
       
        if(transform.position.y < -100)
        {
           playerHp.value = 0;
        }
        if (playerHp.value <= 99)
        {
            noHit = false;
            Debug.Log("no trophe");
        }
        if (playerHp.value < 1)
        {
            audioManger.audioSource.clip = audioManger.audioClip1;
            audioManger.audioSource.Play();
            Main.start = false;
            SceneManager.LoadScene(1);
           
            



        }
        Vector3 moveDirection = Vector3.zero;

      //  ver = Input.GetAxis("Vertical");
      //  horiz = Input.GetAxis("Horizontal");
        animator.SetFloat("ver", vertical);
        animator.SetFloat("horiz", horizontal);


        if (vertical > 0.5 && !rolling && !attacking)
        {
            moveDirection += cam.transform.forward;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
            //transform.Rotate(Vector3.up, cam.transform.rotation.y);
        }
        if (vertical < -0.5 && !rolling && !attacking)
        {
            moveDirection -= cam.transform.forward;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
        }

        if (horizontal > 0.5 && !rolling && !attacking)
        {
            moveDirection += cam.transform.right;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);

        }
        if (horizontal < -0.5 && !rolling && !attacking)
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


        if (lockButton && wait == true)
        {
            if (cam == playerCam)
            {
                cam = targetCam;
            }
            else if (cam == targetCam)
            {
                cam = playerCam;
            }
            wait = false;
            lockButton = false;
        }
        else { wait = true; }

        if (rollButton && vertical > 0.5 && !rolling && !attacking && !rollCoolDown)
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
        if (rollButton && vertical < -0.5 && !rolling && !attacking && !rollCoolDown)
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
        if (rollButton && horizontal > 0.5 && !rolling && !attacking  && !rollCoolDown)
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
        if (rollButton && horizontal < -0.5 && !rolling && !attacking  && !rollCoolDown)
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
            rb.AddForce(transform.forward * rollspeed * Time.deltaTime);
        }
        if (rolling && Brolling )
        {
            rb.AddForce(transform.forward * -rollspeed * Time.deltaTime);
        }
        if (fireButton && !attacking && !rolling)
        {
            attacking = true;
            Instantiate(sound, transform.position, transform.rotation);
            

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
        rb.AddForce(Vector3.forward * 5 * Time.deltaTime);
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

    void Ult()
    {
        gameObject.SetActive(false);
        Invoke("UltEnd",25);
    }
    void UltEnd ()
    {
        gameObject.SetActive(true);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void MoveInput(Vector2 context)
    {
        horizontal = context.x;
        vertical = context.y;
    }

    public void RollInput(bool newJumpState)
    {
        rollButton = newJumpState;
    }
    public void OnRoll(InputValue value)
    {
        RollInput(value.isPressed);
    }
    public void LockInput(bool newJumpState)
    {
        lockButton = newJumpState;
    }
    public void OnLock(InputValue value)
    {
        LockInput(value.isPressed);
    }
    public void AttackInput(bool newJumpState)
    {
        fireButton = newJumpState;
    }
    public void OnAttack(InputValue value)
    {
        AttackInput(value.isPressed);
    }
    public void Roll(InputAction.CallbackContext context)
    {
        rollButton = context.ReadValueAsButton();
    }
    public void Lock(InputAction.CallbackContext context)
    {
        lockButton = context.ReadValueAsButton();
    }
    public void Fire(InputAction.CallbackContext context)
    {
        fireButton = context.ReadValueAsButton();
    }
    public void Ult(InputAction.CallbackContext context)
    {
        ultButton = context.ReadValueAsButton();
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
    }
}