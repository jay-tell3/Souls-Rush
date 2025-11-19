using UnityEngine;

public class HitBox : MonoBehaviour
{
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
        if (other.CompareTag("Player")) // Replace "Player" with your desired tag
        {
            Debug.Log("ouch!!");
            player.playerHp.value -= 30;
        }
    }
}
