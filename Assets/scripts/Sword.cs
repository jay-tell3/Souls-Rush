using UnityEngine;

public class Sword : MonoBehaviour
{
    // public ParticleSystem fire;
    public Boss1 boss1;
    public Boss2 boss2;
    public Boss3 boss3; 
    public Player player;
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
        if (other.CompareTag("enemy") && player.attacking) // Replace "Player" with your desired tag
        {
            Debug.Log("enemy entered the trigger!");
            // Perform actions specific to the Player entering
            boss1.boss1Hp.value -= 2;
            boss3.boss3Hp.value -= 5;
            
            if ( !boss2.inAn)
            {
             if (!boss2.inPhase2 )
             {
             boss2.boss2Hp.value -= 6;
             }
             else
             {
              boss2.boss2Hp.value -= 12;
             }
            }
            

        }

    }
   
}
