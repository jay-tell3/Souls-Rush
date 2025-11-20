using UnityEngine;

public class GamerManger : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject everthing;
    public int BossDefeats;
    public GameObject boss2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   //     everthing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (BossDefeats == 1)
        {
            boss2.SetActive(true);
        }
    }
    public void Starter ()
    {
     startScreen.SetActive(false);
     everthing.SetActive(true);
    }
}
