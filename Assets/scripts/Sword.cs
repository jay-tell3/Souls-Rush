using UnityEngine;

public class Sword : MonoBehaviour
{
    // public ParticleSystem fire;
    public Boss1 boss1;
    
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
        // Check if the entering collider has a specific tag
        if (other.CompareTag("enemy")) // Replace "Player" with your desired tag
        {
            Debug.Log("enemy entered the trigger!");
            // Perform actions specific to the Player entering
        }

    }
}
