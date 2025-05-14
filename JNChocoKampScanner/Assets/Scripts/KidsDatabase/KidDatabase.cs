using Assets.KidsDatabase;
using System.Collections.Generic;

public static class KidDatabase
{
    public static List<Kid> AllKids = new();

    public static void InitDatabase()
    {
        foreach (var barcode in BarcodeDatabase.Barcodes)
        {

        }
    }
}
