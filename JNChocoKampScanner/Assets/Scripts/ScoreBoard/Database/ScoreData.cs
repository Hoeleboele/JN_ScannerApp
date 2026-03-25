using JetBrains.Annotations;

[System.Serializable]
public class ScoreData
{
    public int score;
    public string color;
    public int starAmount;
    public ScoreData(int score, string color, int starAmount)
    {
        this.score = score;
        this.color = color;
        this.starAmount = starAmount;
    }
}