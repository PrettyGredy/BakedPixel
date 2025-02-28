using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Saver
{
    public static class SaveSystem
    {
        private static string savePath = Application.persistentDataPath + "/GameDataSave.data";
        private static int key = 1507;
        
        public static void SaveData(InventoryDataSave dataSave)    
        {
            string json = JsonConvert.SerializeObject(dataSave);
            File.WriteAllText(savePath, EncryptDecrypt(json));
            Debug.Log("GamaData save");
        }
        
        public static InventoryDataSave LoadData()
        {
            if (File.Exists(savePath))
            {
                try
                {
                    string source = File.ReadAllText(savePath);

                    // Проверка на пустой файл
                    if (string.IsNullOrEmpty(source))
                    {
                        Debug.LogError("Save file is empty!");
                        return null;
                    }

                    InventoryDataSave saveData = JsonConvert.DeserializeObject<InventoryDataSave>(EncryptDecrypt(source));
                    return saveData;
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"Loading data error: {e.Message}");
                    return null;
                }
            }
            else
            {
                Debug.LogError("No save found!");
                return null;
            }
        }
        
        
        private static string EncryptDecrypt(string textToEncrypt)    
        {
            StringBuilder inSb = new StringBuilder(textToEncrypt);
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key);
                outSb.Append(c);
            }

            return outSb.ToString();
        }
    }
}