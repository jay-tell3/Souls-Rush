using UnityEngine;

public class BossStart : MonoBehaviour
{
    public GameObject boss;
    public GameObject doors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        boss.SetActive(true);
        doors.SetActive(true);
    }
}
