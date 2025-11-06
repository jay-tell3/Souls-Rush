using UnityEngine;

public class GamerManger : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject everthing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   //     everthing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Starter ()
    {
     startScreen.SetActive(false);
     everthing.SetActive(true);
    }
}
