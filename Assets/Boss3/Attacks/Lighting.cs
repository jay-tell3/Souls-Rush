using Unity.Mathematics;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    bool hitIsBoxActive;
    private ParticleSystem pSystem;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pSystem = GetComponent<ParticleSystem>();
        
        Invoke("Hit",2.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Hit()
    {
        hitIsBoxActive=true;
        Invoke("Nohit", 0.5f);
    }
    void Nohit()
    {
        hitIsBoxActive = false;
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && hitIsBoxActive) // Replace "Player" with your desired tag
        {
            player.playerHp.value -= 1;


        }

    }

}
