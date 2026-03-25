using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleToScoreData : MonoBehaviour
{
    [SerializeField]
    private List<BlockSpawner> spawners = new List<BlockSpawner>();

    private void Start()
    {
        ScoreData[] loadedData = ScoreBoardDatabase.Instance.ScoreData;
        if (loadedData != null)
        {
            StartCoroutine(SpawnBlocks(loadedData));
        }
    }

    private IEnumerator SpawnBlocks(ScoreData[] loadedData)
    {
        foreach (var data in loadedData)
        {
            var spawner = spawners.Find(s => s.ColorName == data.color);
            if (spawner != null)
            {
                StartCoroutine(LoadTower(spawner, data.score));

                spawner.SetAmountOfStars(data.starAmount);
            }

            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator LoadTower(BlockSpawner spawner, int score)
    {
        for (int i = 0; i < score; i++)
        {
            spawner.SpawnBlock();
            spawner.ResetTimer();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveAllCastles();
        }
    }

    private void OnDestroy()
    {
        SaveAllCastles() ;
    }

    private void SaveAllCastles()
    {
        List<ScoreData> scoreDataList = new List<ScoreData>();
        foreach (var spawner in spawners)
        {
            ScoreData data = new ScoreData(spawner.SpawnedBlocks.Count, spawner.ColorName, spawner.StarAmount);
            scoreDataList.Add(data);
        }
        ScoreBoardDatabase.Instance.UpdateScore(scoreDataList.ToArray());
        ScoreBoardDatabase.Instance.SaveScore();
    }
}
