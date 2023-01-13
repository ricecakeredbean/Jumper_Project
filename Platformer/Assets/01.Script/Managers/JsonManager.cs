using UnityEngine;
using System.IO;

public static class JsonManager
{
    public static void Save<T>(T data,string path)
    {
        string saveData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath+"/data"+ path, saveData);
    }

    public static T Load<T>(string path)
    {
        return JsonUtility.FromJson<T>(Application.dataPath+"/data"+ path);
    }
}
