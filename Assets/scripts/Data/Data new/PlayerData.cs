using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool noHitTroph;
    public bool noCamTroph;
    public bool noHealTroph;
    public bool goldTroph;

    private static PlayerData instance;

    public static PlayerData Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        LoadPlayer();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       // LoadPlayer();
    }
  

    void LoadPlayer()
    {

      TrophyData data = SaveData.LoadData();
        noHitTroph = data.noHitTroph;
        noHealTroph = data.noHealTroph;
        noCamTroph = data.noCamTroph;
        goldTroph = data.goldTroph;
    }

    public void Del()
    {
        noHitTroph = false;
        noHealTroph = false;
        noCamTroph = false;
        goldTroph = false ;
    }




}
