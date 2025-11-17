using UnityEngine;

public class BruningAttack : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem par;
    public ParticleSystem par2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
       
    } 
   public void A1()
    {
        Debug.Log("hyjgf");
        transform.position = player.transform.position;
        par.Play();
        Invoke("A2",1f);
    }
    void A2()
    {
        Debug.Log("A2");
        par.Stop();
        par2.Play();
        Invoke("End", 2f);
    }
    void End()
    {
        Debug.Log("End");
        par2.Stop();
    }

    void OnParticleTrigger()
    { 
        Debug.Log("parrrrrr");
        
    }
}
