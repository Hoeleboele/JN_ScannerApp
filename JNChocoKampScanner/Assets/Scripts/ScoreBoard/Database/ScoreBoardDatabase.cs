using UnityEngine;

public class ScoreBoardDatabase : MonoBehaviour
{
    [SerializeField]
    private IDatabase database;

    private ScoreData[] scoreData;

    public ScoreData[] ScoreData => scoreData;

    private void Awake()
    {
        if (database == null)
        {
            Debug.LogError("Database reference is not set in ScoreBoardDatabase.");
        }

        scoreData = database.LoadScore();
    }

    public void UpdateScore(ScoreData data)
    {
        //update the score data with the new score data
        for (int i = 0; i < scoreData.Length; i++)
        {
            if (scoreData[i].color == data.color)
            {
                scoreData[i].score = data.score;
                return;
            }
        }

        //if the color is not found in the score data error that its not saved try again
        Debug.LogError("Color not found in score data. Score not updated.");
    }

    public void SaveScore()
    {
        database.SaveScore(scoreData);
    }
}
