using UnityEngine;

public class Sword : MonoBehaviour
{
    // public ParticleSystem fire;
    public Boss1 boss1;
    public Boss2 boss2;
    public Boss3 boss3; 
    public Player player;
    public GameObject pinkFlash;
    private int pFlash = 101;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (boss1.isActive == true)
        {
            Debug.Log("on");
        }
        else
        {
            Debug.Log("off");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("enemy") && player.attacking) // Replace "Player" with your desired tag
        {
            Debug.Log("enemy entered the trigger!");
            // Perform actions specific to the Player entering
            if (boss1.isActive) 
            {
                if (Random.Range(1, 101) == 1)
                {

                    Instantiate(pinkFlash, transform.position, transform.rotation);
                    boss1.boss1Hp.value -= 20;
                }
                else
                {
                    boss1.boss1Hp.value -= 2;
                }
            }
            if (boss3.isActive)
            {
                if (Random.Range(1, 101) == 1)
                {
                    Instantiate(pinkFlash, transform.position, transform.rotation);
                    boss3.boss3Hp.value -= 20;
                }
                else
                {
                    boss3.boss3Hp.value -= 2;
                }
            }
            if (boss2.isActive)
            {
                if (!boss2.inAn)
                {
                    if (!boss2.inPhase2)
                    {

                        if (Random.Range(1, 101) == 1)
                        {
                            Instantiate(pinkFlash, transform.position, transform.rotation);
                            boss2.boss2Hp.value -= 30;
                        }
                        else
                        {
                            boss2.boss2Hp.value -= 6;
                        }

                    }
                    else
                    {
                        if (Random.Range(1, 101) == 1)
                        {
                            Instantiate(pinkFlash, transform.position, transform.rotation);
                            boss2.boss2Hp.value -= 20;
                        }
                        else
                        {
                            boss2.boss2Hp.value -= 4;
                        }
                    }

                }
            }

        }

    }

    
}
