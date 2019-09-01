using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
   public static GameData data = new GameData();

   public static void Save()
   {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/player.gd");
        bf.Serialize(file, data);
        file.Close();
   }

   public static void Load()
   {
        if (File.Exists(Application.persistentDataPath + "/player.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.gd", FileMode.Open);
            SaveLoad.data = (GameData)bf.Deserialize(file);
            Debug.Log(data.spaceships);
            file.Close();
        }
   }
}
