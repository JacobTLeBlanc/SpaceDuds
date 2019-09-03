using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public static class SaveLoad
{
   // Data
   public static GameData data = new GameData();

   public static void Save()
   {
        // Create BinaryFormatter
        BinaryFormatter bf = new BinaryFormatter();

        // Create Path/File
        FileStream file = File.Create(Application.persistentDataPath + "/player.gd");

        // Serialize data on file
        bf.Serialize(file, data);

        // Close file
        file.Close();
   }

   public static void Load()
   {
        if (File.Exists(Application.persistentDataPath + "/player.gd")) // Check if file exits
        {
            // Create BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();

            // Open File
            FileStream file = File.Open(Application.persistentDataPath + "/player.gd", FileMode.Open);

            // Get Data by Deserializing
            SaveLoad.data = (GameData)bf.Deserialize(file);

            // Close File
            file.Close();
        }
   }

    public static void Delete()
    {
        // Delete File
        try
        {
            File.Delete(Application.persistentDataPath + "/player.gd");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
