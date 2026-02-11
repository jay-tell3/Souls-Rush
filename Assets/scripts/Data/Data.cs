using UnityEngine;

[System.Serializable]
public class Data : MonoBehaviour
{
    public int Boss; 

    public Data (GamerManger gamerManger)
    {
        Boss = gamerManger.BossDefeats;
    }
    
}
