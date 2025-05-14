using Assets.KidsDatabase;
using UnityEngine;

public class DatabaseLoader : MonoBehaviour
{
    private void Awake()
    {
        BarcodeDatabase.InitDatabase();
        KidDatabase.InitDatabase();
    }
}
