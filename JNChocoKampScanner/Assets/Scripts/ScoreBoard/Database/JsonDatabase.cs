using System;
using System.IO;
using UnityEngine;

public class JsonDatabase : IDatabase
{
    private const string jsonFilePath = "./JsonDatabase.json";

    public ScoreData[] LoadScore()
    {
        var jsonText = string.Empty;

        try
        {
            //load the data from the json file and return it as a ScoreData list object
            if (!File.Exists(jsonFilePath))
            {
                return null;
            }

            jsonText = File.ReadAllText(jsonFilePath);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading score data from JSON: " + ex.Message);
        }

        var jsonConverted = JsonHelper.FromJson<ScoreData>(jsonText);
        return jsonConverted;
    }

    public void SaveScore(ScoreData[] scoreData)
    {
        try
        {
            var json = JsonHelper.ToJson(scoreData, true);
            System.IO.File.WriteAllText(jsonFilePath, json);
            Debug.Log($"Saved json object to file");
            Debug.Log($"Object: {json}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error saving score data to JSON: " + ex.Message);
        }
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}