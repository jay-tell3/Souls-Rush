using UnityEngine;

public class Main : MonoBehaviour
{

    public static bool noHitTroph = false;
    public GameObject nohitX;
    public GameObject nohitCheckMark;
    public static bool noCamTroph = true;
    public GameObject nocamX;
    public GameObject nocamCheckMark;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        noCamTroph = true;
        if (noHitTroph)
        {
            nohitX.SetActive(false);
            nohitCheckMark.SetActive(true);
        }
        else
        {
            nohitX.SetActive(true);
            nohitCheckMark.SetActive(false);
        }

        if (noCamTroph == true)
        {
            nohitX.SetActive(false);
            nohitCheckMark.SetActive(true);
        }
        else
        {
            nohitX.SetActive(true);
            nohitCheckMark.SetActive(false);
        }

    }
    public void BossSeclect(int boss)
    { 
        GamerManger.BossDefeats = boss;
    }
}
