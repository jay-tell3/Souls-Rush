using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveData
{
   public static void SavePlayerData (PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        TrophyData data = new TrophyData(playerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TrophyData LoadData ()
    {
        string path = Application.persistentDataPath + "/saveData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
                
            FileStream stream = new FileStream(path, FileMode.Open);
            TrophyData data = formatter.Deserialize(stream) as TrophyData;

            stream.Close();
            return data;
        }
        else
        {
            // Debug.LogError("Save File not found in " + path);
            TrophyData data = new TrophyData();
            return data;
        }
    }
    public static void DelData()
    {
        string path = Application.persistentDataPath + "/saveData.fun";
        if (File.Exists(path))
        {
            File.Delete(path);
            PlayerData.Instance.Del();
        }
    }
}
