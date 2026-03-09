using System;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public int bossDoor = 0;
    public GameObject door;
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
        if (other.CompareTag("Player")) // Replace "Player" with your desired tag
        {
            if (GamerManger.BossDefeats == bossDoor)
            {
                door.SetActive(true);
            }
        }
 
    }
}
