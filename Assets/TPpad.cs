using UnityEngine;

public class TPpad : MonoBehaviour
{
    public GameObject player;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {

        // You can also use other.CompareTag("YourTag") to check for specific objects
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(14, -0.8337161f, -23);
           
        }
    }
}
