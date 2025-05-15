using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeestDagenManager : MonoBehaviour
{
    #region Singleton
    public static FeestDagenManager Instance;

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
    }
    #endregion


    [SerializeField]
    private List<FeestDag> allFeestDagen = new List<FeestDag>();

   public List<FeestDag> AllFeestDagen => allFeestDagen;

    public void ShowFeestdagFromType(FeestDagType feestDagType)
    {
        allFeestDagen.ForEach(fd => fd.Hide());

        allFeestDagen.Find(fd => fd.FeestDagType == feestDagType)?.Show();
    }
}
