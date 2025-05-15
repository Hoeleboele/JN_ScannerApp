using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeestdagButtonMaker : MonoBehaviour
{
    [SerializeField]
    private FeestdagButton buttonPrefab;

    void Start()
    {
        foreach (var feestdag in FeestDagenManager.Instance.AllFeestDagen)
        {
            var button = Instantiate(buttonPrefab,transform);
            button.Init(feestdag.FeestDagType);
        }
    }
}
