using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{   //variable place
    public Rigidbody rb;
    public GameObject cam;
    public Animator animator;
    
    
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

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += cam.transform.forward;
            animator.SetBool("moving", true);
        }
        else { animator.SetBool("moving", false); }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= cam.transform.forward;
           // animator.SetBool("moving", true);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += cam.transform.right;
           // animator.SetBool("moving", true);

        }
      
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= cam.transform.right;
           // animator.SetBool("moving", true);
        }
        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }*/


        moveDirection.Normalize(); // To prevent faster diagonal movement
        moveDirection *= 5f; // Speed

        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        
    }
    
}
