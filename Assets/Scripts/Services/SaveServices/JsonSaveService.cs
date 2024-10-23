using System.IO;
using UnityEngine;

public class JsonSaveService : ISaveService
{
  private readonly string savePath;

  public JsonSaveService()
  {
    savePath = Application.persistentDataPath;
  }

  public void Save<T>(string saveName, T gameState) 
    where T : class
  {
    saveName = Path.ChangeExtension(saveName, "json");
    string json = JsonUtility.ToJson(gameState);
    string fullFilename = Path.Combine(savePath, saveName);
    File.WriteAllText(fullFilename, json);
  }

  public bool Exists(string saveName){
    saveName = Path.ChangeExtension(saveName, "json");
    string fullFilename = Path.Combine(savePath, saveName);
    return File.Exists(fullFilename);
  }

  public T Load<T>(string saveName) 
    where T : class
  {
    saveName = Path.ChangeExtension(saveName, "json");
    string fullFilename = Path.Combine(savePath, saveName);

    if(!File.Exists(fullFilename))
      throw new System.Exception($"File does not exists {fullFilename}");

    string json = File.ReadAllText(fullFilename);
    T gameState = JsonUtility.FromJson<T>(json);
    return gameState;
  }
}