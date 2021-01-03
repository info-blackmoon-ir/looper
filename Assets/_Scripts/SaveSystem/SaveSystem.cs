using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SaveSys {

    public class SaveSystem : MonoBehaviour
    {
        public static void SaveData(Looper[] loopers, string num)
        {
            BinaryFormatter binary = new BinaryFormatter();
            string path = Application.persistentDataPath + num + ".Data";
            //FileStream file = new FileStream(path, FileMode.CreateNew);
            FileStream file = File.Create(path);
            
            LooperData data = new LooperData(loopers);
            binary.Serialize(file, data);
            file.Close();
        }

        public static LooperData LoadData(string num)
        {
            string path = Application.persistentDataPath + num + ".Data";
            if (File.Exists(path))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);
                LooperData data = binary.Deserialize(file) as LooperData;
                file.Close();
                
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
