using UnityEngine;

public class Heal : MonoBehaviour
{
    public static bool noHeal = true;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Main.start == true || GamerManger.BossDefeats == 0)
        {
            noHeal = true;
        }
        else
        {
            noHeal = false;
            Debug.Log("trporpopr nooo");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {

        // You can also use other.CompareTag("YourTag") to check for specific objects
        if (other.CompareTag("Player"))
        {
            noHeal = false;  
            player.playerHp.value += 1;
        }
    }
}
