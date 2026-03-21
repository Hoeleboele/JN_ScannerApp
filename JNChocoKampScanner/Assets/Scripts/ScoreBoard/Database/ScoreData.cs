[System.Serializable]
public class ScoreData
{
    public int score;
    public string color;
    public ScoreData(int score, string color)
    {
        this.score = score;
        this.color = color;
    }
}