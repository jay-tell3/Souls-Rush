using System.Security.Cryptography;
using UnityEngine;

public class FireNadow : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Invoke("Despawn",6f);
    }
    /*
    public Transform target;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    */
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * 8 * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player")) // Replace "Player" with your desired tag
        {
            player.playerHp.value -= 20;
            Debug.Log("awsedrftgyhj");
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
