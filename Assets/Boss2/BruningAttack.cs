using UnityEngine;

public class BruningAttack : MonoBehaviour
{
    public GameObject player;
    public Player play;
    public ParticleSystem par;
    public ParticleSystem par2;
    public float parRad = 1;
    private ParticleSystem.ShapeModule shapeModule;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shapeModule = par2.shape;
    }
    
    // Update is called once per frame
    void Update()
    {
         shapeModule.radius = parRad; // Set initial radius
         parRad += 0.1f;
        transform.Rotate(0, 150 * Time.deltaTime, 0);
    } 
   public void A1()
    {

        Debug.Log("hyjgf");
        transform.position = player.transform.position;
        par.Play();
        //audioSource.Play();
        Invoke("A2",1f);
    }
    void A2()
    {
        parRad = 1;
        Debug.Log("A2");
        par.Stop();
        par2.Play();
        Invoke("End", 1f);
    }
    void End()
    {
        Debug.Log("End");
        par2.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {

        // You can also use other.CompareTag("YourTag") to check for specific objects
        if (other.CompareTag("Player"))
        {
            play.playerHp.value -= 30;

        }
    }
}
