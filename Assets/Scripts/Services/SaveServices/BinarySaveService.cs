using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinarySaveService : ISaveService
{
  private readonly string savePath;

  public BinarySaveService()
  {
    savePath = Application.persistentDataPath;
  }

  public void Save<T>(string saveName, T gameState)
    where T : class
  {
    string path = savePath + "/" + saveName;
    FileStream fileStream = new(path, FileMode.Create);
    BinaryFormatter formatter = new();
    formatter.Serialize(fileStream, gameState);
    fileStream.Close();
  }

  public bool Exists(string saveName)
  {
    string fullFilename = Path.Combine(savePath, saveName);
    return File.Exists(fullFilename);
  }

  public T Load<T>(string fileName)
    where T : class
  {
    string path = savePath + "/" + fileName;
    if (File.Exists(path))
    {
      FileStream fileStream = new(path, FileMode.Open);
      BinaryFormatter formatter = new BinaryFormatter();
      T data = formatter.Deserialize(fileStream) as T;
      fileStream.Close();
      return data;
    }
    else
    {
      throw new System.Exception("Save does not exists");
    }
  }
}