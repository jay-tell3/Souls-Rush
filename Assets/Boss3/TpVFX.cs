using UnityEngine;

public class TpVFX : MonoBehaviour
{
    public Transform Boss3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TP()
    {
        transform.position =  Boss3.position;
    }
}
