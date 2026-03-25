using UnityEngine;

public class ScoreBoardDatabase : MonoBehaviour
{
    #region Singleton
    public static ScoreBoardDatabase Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (database == null)
        {
            database = new JsonDatabase();
        }

        scoreData = database.LoadScore();
        Debug.Log($"score datas amount loaded: {scoreData?.Length}");
    }
    #endregion


    private IDatabase database;

    private ScoreData[] scoreData;

    public ScoreData[] ScoreData => scoreData;

    public void UpdateScore(ScoreData[] data)
    {
        scoreData = data;
    }

    public void SaveScore()
    {
        database.SaveScore(scoreData);
    }
}
