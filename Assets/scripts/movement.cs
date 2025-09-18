using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{   //variable place
    public Rigidbody rb;
    public GameObject cam;
    public Animator animator;
    private float ver, horiz;
    public bool rolling;
    public bool Frolling;
    public bool Brolling;
    public bool Rrolling;
    public bool Lrolling;
    private float attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        Vector3 moveDirection = Vector3.zero;

        ver = Input.GetAxis("Vertical");
        horiz = Input.GetAxis("Horizontal");
        animator.SetFloat("ver", ver);
        animator.SetFloat("horiz",horiz);
        

        if (ver > 0 && !rolling)
        {
            moveDirection += cam.transform.forward;
            transform.localRotation =  Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
            //transform.Rotate(Vector3.up, cam.transform.rotation.y);
        }
        if (ver < 0 && !rolling)
        {
            moveDirection -= cam.transform.forward;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
        }

        if (horiz > 0 && !rolling)
        {
            moveDirection += cam.transform.right;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);

        }
        if (horiz < 0 && !rolling)
        {
            moveDirection -= cam.transform.right;
            transform.localRotation = Quaternion.Euler(transform.rotation.x, cam.transform.eulerAngles.y, transform.rotation.z);
        }
       
        
        
        if (Input.GetKey(KeyCode.E) && ver > 0 && !rolling)
        {
            rolling = true;
            //StartCoroutine(MoveRoll());
            
             animator.SetTrigger("Roll");
            Invoke("NoRoll", 1f);
        }
        if (Input.GetKey(KeyCode.E) && ver < 0 && !rolling)
        {
            Brolling = true;
            rolling = true;
            animator.SetTrigger("Roll");
            Invoke("NoRoll", 1f);
        }
        if (Input.GetKey(KeyCode.E) && horiz > 0 && !rolling)
        {
            rolling = true;
            //StartCoroutine(MoveRoll());
            animator.SetTrigger("sideRoll");
            transform.Rotate(0, 90, 0);
            Invoke("NoRoll", 1f);
        }
        if (Input.GetKey(KeyCode.E) && horiz < 0 && !rolling)
        {
            rolling = true;
            animator.SetTrigger("sideRoll");
            transform.Rotate(0, -90, 0);
            Invoke("NoRoll", 1f);
        }
       
        if (rolling && !Brolling )
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
        if (rolling && Brolling)
        {
            transform.Translate(Vector3.forward * -5 * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            attack = Random.Range(0,3);
            animator.SetFloat("attack", attack);
            animator.SetTrigger("Attack");
        }

        moveDirection.Normalize(); // To prevent faster diagonal movement
        moveDirection *= 5f; // Speed

        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        
    }

    public void NoRoll()
    {
        rolling = false;
        Frolling = false;
        Brolling = false;
        Rrolling = false;
        Lrolling = false;

    }
   
    public IEnumerator MoveRoll()
    {
       // while (rolling)
            //transform.Translate(Vector3.forward * 10 * Time.deltaTime); 
            transform.Translate(Vector3.forward * 5);
        yield return null;
       
    }
    
}
