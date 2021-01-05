using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SaveSys {

    public class SaveSystem : MonoBehaviour
    {
        public static void SaveData(Looper looper, string name,string number)
        {
            var folder = Directory.CreateDirectory(Application.persistentDataPath + "/" + name);
            string path = Application.persistentDataPath + "/" + name + "/" + "Loop" + number + ".data";
            BinaryFormatter binary = new BinaryFormatter();
            
            //FileStream file = new FileStream(path, FileMode.CreateNew);
            FileStream file = File.Create(path);
            Debug.Log("File has been Saves into : " + path);
            binary.Serialize(file, looper);
            file.Close();

            
        }

        public static void SaveConfig(string name,string number)
        {
            string path = Application.persistentDataPath + "/" + name + "/" + "Loop.config";
            BinaryFormatter binary = new BinaryFormatter();

            //FileStream file = new FileStream(path, FileMode.CreateNew);
            FileStream file = File.Create(path);
            Debug.Log("File has been Saves into : " + path);
            binary.Serialize(file, number);
            file.Close();
        }

        public static Looper LoadData(string name,string number)
        {
            var folder = Directory.CreateDirectory(Application.persistentDataPath + "/"+ name);
            string path = Application.persistentDataPath + "/" + name + "/" + "Loop" + number + ".data";
            if (File.Exists(path))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);
                Looper data = binary.Deserialize(file) as Looper;
                file.Close();
                
                return data;
            }
            else
            {
                return null;
            }
        }

        public static int LoadConfig(string name)
        {
            string path = Application.persistentDataPath + "/" + name + "/" + "Loop.config";
            if (File.Exists(path))
            {
                BinaryFormatter binary = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);
                string data = binary.Deserialize(file) as string;
                
                file.Close();

                return int.Parse(data);
            }
            else
            {
                return 0;
            }
        }
        
    }
}
