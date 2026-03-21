using UnityEngine;

public interface IDatabase
{
    public void SaveScore(ScoreData[] scoreData);
    public ScoreData[] LoadScore();
}
