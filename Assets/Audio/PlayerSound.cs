using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Ddestroy", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ddestroy()
    {
        Destroy(gameObject);
    }
}
