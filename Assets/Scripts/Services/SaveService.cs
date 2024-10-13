using System.IO;
using UnityEngine;

public class SaveService : IService
{
  private readonly string savePath;

  public SaveService()
  {
    savePath = Application.persistentDataPath;
  }

  public void SaveGame<T>(string saveName, T gameState)
  {
    string json = JsonUtility.ToJson(gameState);
    string fullFilename = Path.Combine(savePath, saveName);
    File.WriteAllText(fullFilename, json);
  }

  public bool SaveExists(string saveName){
    string fullFilename = Path.Combine(savePath, saveName);
    return File.Exists(fullFilename);
  }

  public T LoadGame<T>(string saveName)
  {
    string fullFilename = Path.Combine(savePath, saveName);

    Debug.Log(fullFilename);
    if(!File.Exists(fullFilename))
      throw new System.Exception($"File does not exists {fullFilename}");

    string json = File.ReadAllText(fullFilename);
    T gameState = JsonUtility.FromJson<T>(json);
    return gameState;
  }
}