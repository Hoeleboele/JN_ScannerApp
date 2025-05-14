using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeestDagenManager : MonoBehaviour
{
    [SerializeField]
    private List<FeestDag> allFeestDagen = new List<FeestDag>();

    public void ShowFeestdagFromType(FeestDagType feestDagType)
    {
        allFeestDagen.ForEach(fd => fd.Hide());

        allFeestDagen.Find(fd => fd.FeestDagType == feestDagType)?.Show();
    }
}
