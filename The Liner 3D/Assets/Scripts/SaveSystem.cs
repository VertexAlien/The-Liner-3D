using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.Data";
        FileStream stream = new FileStream(path, FileMode.Create);


        LevelData data = new LevelData();


        formatter.Serialize(stream, data);
        stream.Close();
    }

    

    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.Data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return data;
        }

        else
        {
            return null;
        }
    }
}
