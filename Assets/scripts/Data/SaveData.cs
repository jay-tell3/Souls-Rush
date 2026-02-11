using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveData
{
   public static void SaveManger (GamerManger gamerManger)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(gamerManger);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data loadData ()
    {
        string path = Application.persistentDataPath + "/saveData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
                
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(stream) as Data;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File noy found in " + path);
            return null;
        }
    }
}
