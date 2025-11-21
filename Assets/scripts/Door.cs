using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Open()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(0, -1, 0);
        }
        opened = true;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has a specific tag
        if (other.CompareTag("Player") && !opened) // Replace "Player" with your desired tag
        {

            Open();
        }
    }
}
