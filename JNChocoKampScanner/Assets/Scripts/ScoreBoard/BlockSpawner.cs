using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private CastleBlock blockPrefab;
    [SerializeField]
    private string colorName;

    private List<CastleBlock> spawnedBlocks = new List<CastleBlock>();
    private TopBlock topBlock;
    private int starAmount = 0;

    public List<CastleBlock> SpawnedBlocks => spawnedBlocks;

    public string ColorName  => colorName;
    public int StarAmount  => starAmount;

    private void Awake()
    {
        topBlock = GetComponentInChildren<TopBlock>();
        GetComponent<Button>().onClick.AddListener(SpawnBlock);
        GetComponent<Button>().onClick.AddListener(ResetTimer);
    }

    public void SetAmountOfStars(int amount)
    {
        starAmount = amount;
    }

    public void SpawnBlock()
    {
        var block = Instantiate(blockPrefab, parentObject);
        block.transform.position = spawnLocation.position;
        spawnedBlocks.Add(block);
        spawnLocation.position += new Vector3(0, 101, 0);
    }

    public void ResetTimer()
    {
        topBlock.ResetRespawnTimer();
    }
}
