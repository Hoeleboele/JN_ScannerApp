using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private const float TimeToBeScanned = 3f;

    [SerializeField]
    private GameObject correctColor;
    [SerializeField]
    private GameObject wrongColor;
    [SerializeField]
    private GameObject defaultColor;

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScanned += OnBarcodeScanned;
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScanned -= OnBarcodeScanned;
    }

    private void OnBarcodeScanned(Kid scannedKid)
    {
        if (defaultColor.activeSelf)
        {
            if (scannedKid.IsCorrectCode)
            {
                SwapColor(correctColor);
            }

            if (scannedKid.IsCorrectCode == false)
            {
                SwapColor(wrongColor);
            }
        }
    }

    private void SwapColor(GameObject colorObject)
    {
        ResetColors();
        colorObject.SetActive(true);
        defaultColor.SetActive(false);
        StartCoroutine(DelayedReset());
    }

    private void ResetColors()
    {
        correctColor.SetActive(false);
        wrongColor.SetActive(false);

        defaultColor.SetActive(true);
    }

    private IEnumerator DelayedReset()
    {
        yield return new WaitForSeconds(TimeToBeScanned);
        ResetColors();
    }
}
