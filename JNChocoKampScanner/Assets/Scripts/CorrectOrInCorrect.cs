using System;
using UnityEngine;

public class CorrectOrInCorrect : MonoBehaviour
{
    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScanned += OnCodeScanned;
    }

    private void OnCodeScanned(Kid scannedKid)
    {
        if (scannedKid.IsCorrectCode)
        {
            Channels.ColorChangeChannel.OnCorrectKidScanned?.Invoke(scannedKid);
        }
        else
        {
            Channels.ColorChangeChannel.OnInCorrectKidScanned?.Invoke(scannedKid);
        }
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScanned -= OnCodeScanned;
    }
}
