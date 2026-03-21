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

    private List<CastleBlock> spawnedBlocks = new List<CastleBlock>();

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(SpawnBlock);
    }

    private void SpawnBlock()
    {
        var block = Instantiate(blockPrefab, parentObject);
        block.transform.position = spawnLocation.position;
        spawnedBlocks.Add(block);
        spawnLocation.position += new Vector3(0, 100, 0);
    }
}
