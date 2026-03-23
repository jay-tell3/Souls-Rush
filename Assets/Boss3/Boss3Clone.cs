using UnityEngine;

public class Boss3Clone : MonoBehaviour
{
    public Animator animator;
    private bool attack = false;
    private Transform target;
    private Boss3 B3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        B3 = GameObject.Find("Boss3").GetComponent<Boss3>();
        target = GameObject.FindWithTag("Player").transform;
        animator.SetFloat("walkT",Random.Range(0,3));
        Invoke("Sattack", 0.8f);

    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            animator.SetTrigger("Attack");
            transform.Translate(Vector3.forward * 30 * Time.deltaTime);
            Invoke("Destroyy", 5);
        }

        if (B3.tried == true)
        {
            Destroy(gameObject);
        }
    }

    void Sattack()
    {
        if (B3.clones == 1)
        {


            attack = true;

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
            Destroy(gameObject);
        }
    }
    void Destroyy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") ) // Replace "Player" with your desired tag
        {
            Debug.Log("work");
            B3.Hitplayer();
        }
    }
}
