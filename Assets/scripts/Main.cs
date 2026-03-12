using UnityEngine;

public class Main : MonoBehaviour
{

    public static bool noHitTroph = false;
    public GameObject nohitX;
    public GameObject nohitCheckMark;
    public static bool noCamTroph = false;
    public GameObject nocamX;
    public GameObject nocamCheckMark;
    public static bool noHealTroph = false;
    public GameObject nohealX;
    public GameObject nohealCheckMark;
    public static bool goldTroph = false;
    public GameObject nogoldX;
    public GameObject nogoldCheckMark;

    public static bool start = false;
    public static bool start2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (noCamTroph && noHealTroph && noHitTroph)
        {
            goldTroph = true;
        }
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
            nocamX.SetActive(false);
            nocamCheckMark.SetActive(true);
        }
        else
        {
            nocamX.SetActive(true);
            nocamCheckMark.SetActive(false);
        }

        if (noHealTroph == true)
        {
            nohealX.SetActive(false);
            nohealCheckMark.SetActive(true);
        }
        else
        {
            nohealX.SetActive(true);
            nohealCheckMark.SetActive(false);
        }

        if (goldTroph == true)
        {
            nogoldX.SetActive(false);
            nogoldCheckMark.SetActive(true);
        }
        else
        {
            nogoldX.SetActive(true);
            nogoldCheckMark.SetActive(false);
        }


    }
    public void BossSeclect(int boss)
    { 
        GamerManger.BossDefeats = boss;
    }
    public void Starttt()
    {
        GamerManger.BossDefeats = 0;
        start = true;
        start2 = true;

    }
    public void Bstarttt()
    {
        
        start = false;
        start2 = false;

    }
    public void ResetTrophies()
    {
        goldTroph = false;
        noCamTroph = false;
        noHealTroph = false;
        noHitTroph = false;
    }
}
