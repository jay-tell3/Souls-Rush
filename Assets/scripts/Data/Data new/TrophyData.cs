using UnityEngine;

[System.Serializable]
public class TrophyData
{
    public bool noHitTroph;
    public bool noCamTroph;
    public bool noHealTroph;
    public bool goldTroph;

    public TrophyData ( PlayerData player)
    {
        noHitTroph = player.noHitTroph;
        noCamTroph = player.noCamTroph;
        goldTroph = player.goldTroph;
        noHealTroph = player.noHealTroph;


    }
    public TrophyData()
    {
        noHitTroph = false;
        noCamTroph = false;
        goldTroph = false;
        noHealTroph = false;


    }
}
