using System;
using UnityEngine;

public class GamerManger : MonoBehaviour
{
   
    public GameObject startScreen;
    public GameObject everthing;
    public int BossDefeats = 0;
    public bool Tp = false;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        
    }
    public static GamerManger Instance { get; set; }

    void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // If another instance exists, destroy this one
            Destroy(this.gameObject);
            Debug.LogWarning("Multiple instances of GameManager found! Destroying duplicate.");
        }
        else
        {
            // If no instance exists, set this as the instance
            Instance = this;
            // Optional: keep the object alive across scene changes
             DontDestroyOnLoad(this.gameObject); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (BossDefeats == 0 && player.playerHp.value < 1)
        {
           
        }
        else if (BossDefeats == 1 && player.playerHp.value < 1)
        {
           
        }
        else if (BossDefeats == 2 && player.playerHp.value < 1)
        {
           
        }
        */
    }
    public void Starter ()
    {
     startScreen.SetActive(false);
     everthing.SetActive(true);
    }
    public void BossK()
    {
        BossDefeats += 1;
        Debug.Log("deee");
    }
    public void Tped()
    {
        Tp = true;
    }
}
