using UnityEngine;

public class JsonDatabase : MonoBehaviour, IDatabase
{
    private const string jsonFilePath = "./JsonDatabase";

    public ScoreData[] LoadScore()
    {
        //load the data from the json file and return it as a ScoreData list object
        var jsonConverted = JsonUtility.FromJson<ScoreData[]>(jsonFilePath);
        return jsonConverted;
    }

    public void SaveScore(ScoreData[] scoreData)
    {
        try
        {
            var json = JsonUtility.ToJson(scoreData, true);
            System.IO.File.WriteAllText(jsonFilePath, json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error saving score data to JSON: " + ex.Message);
        }
    }
}
