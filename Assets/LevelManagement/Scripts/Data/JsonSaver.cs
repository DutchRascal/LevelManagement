using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace LevelManagement.Data
{
    public class JsonSaver
    {
        private static readonly string _filename = "saveData1.sav";

        public static string GetSaveFileName()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        public void Save(SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            string saveFilename = GetSaveFileName();
            FileStream fileStream = new FileStream(saveFilename, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData data)
        {
            string loadFilename = GetSaveFileName();
            if (File.Exists(loadFilename))
            {
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    string json = reader.ReadToEnd();
                    JsonUtility.FromJsonOverwrite(json, data);
                }
                return true;
            }
            return false;
        }

        public void Delete()
        {
            File.Delete(GetSaveFileName());
        }
    }
}
