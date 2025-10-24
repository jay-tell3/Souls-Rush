using UnityEngine;

public class Boss1G : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {

        // You can also use other.CompareTag("YourTag") to check for specific objects
        if (other.CompareTag("Player")) { Debug.Log("A particle collided with: " + other.name); }
    }
}
