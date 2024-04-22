using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.PlayerLoop;

public static class SaveManager 
{
       public static void SavePlayerData(MoverCubo player)
       {
              GameData playerData = new GameData(player);
              string file = Application.persistentDataPath + "/player.bin";
              FileStream fileStream = new FileStream(file, FileMode.Create);
              BinaryFormatter binaryFormatter = new BinaryFormatter();
              binaryFormatter.Serialize(fileStream,playerData);
              fileStream.Close();
              Debug.Log("Guardado");
       }

       public static GameData LoadPlayerData()
       {
              string file = Application.persistentDataPath + "/player.bin";
              if (File.Exists(file))
              {
                     FileStream fileStream = new FileStream(file, FileMode.Open);
                     BinaryFormatter binaryFormatter = new BinaryFormatter();
                     GameData playerData = (GameData)binaryFormatter.Deserialize(fileStream);
                     fileStream.Close();
                     Debug.Log("Cargado");
                     return playerData;
              }
              else
              {
                     Debug.Log("erro, fichero no existe");
                     return null;

              }
              
       }
}
