using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerSave
{
    private static string dest = Application.persistentDataPath + "/player.game";
    public static void SavePlayer(Save save)
    {
        BinaryFormatter bf = new BinaryFormatter();      
        FileStream fs = new FileStream(dest, FileMode.Create);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public static Save load()
    {
        if (File.Exists(dest))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(dest, FileMode.Open);
            Save tmp = bf.Deserialize(fs) as Save;
            fs.Close();

            return tmp;
        }
        else
        {
            return null;
        }
    }
}
