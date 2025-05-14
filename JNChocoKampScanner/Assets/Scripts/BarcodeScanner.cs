using Assets.KidsDatabase;
using UnityEngine;

public class BarcodeScanner : MonoBehaviour
{
    private const float timeToResetBarcode = 3f;

    [SerializeField]
    private ExcelBarcodeDatabase database;

    string currentBarcode = "";

    float currentTime = 0;

    void Update()
    {
        if (Input.anyKey)
        {
            var barcode = Input.inputString;

            if (currentBarcode.Length < 5)
                currentBarcode += barcode;
        }
        else
        {
            currentTime += Time.deltaTime;

            if (currentTime < timeToResetBarcode)
                return;

            currentTime = 0;
            currentBarcode = "";
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            var array = currentBarcode.ToCharArray();

            if (array.Length < 5)
                return;

            string trueBarcode = array[0].ToString() + array[1].ToString() + array[2].ToString() + array[3].ToString() + array[4].ToString();

            var kid = database.allKids.Find(k => k.Code == trueBarcode);

            currentBarcode = "";
            currentTime = 0;

            if (kid == null)
                return;

            Channels.ColorChangeChannel.OnCodeScanned?.Invoke(kid);
        }
    }

    public string GetRandomBarcode()
    {
        int rando = Random.Range(0, 2);

        if (rando == 1)
            return "correct";

        if (rando == 0)
            return "wrong";

        return null;
    }
}
