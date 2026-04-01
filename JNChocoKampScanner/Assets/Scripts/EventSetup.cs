using System;
using UnityEngine;
using static ColorChangeChannel;

public class EventSetup : MonoBehaviour
{
    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScanned += OnCodeScanned;
    }

    private void OnCodeScanned(Kid scannedKid)
    {
        switch (scannedKid.IsCorrectCode)
        {
            case 0:
                Channels.ColorChangeChannel.OnInCorrectKidScanned?.Invoke(scannedKid);
                break;
            case 1:
                Channels.ColorChangeChannel.OnCorrectKidScanned?.Invoke(scannedKid);
                break;
            case 2:
                Channels.ColorChangeChannel.OnInPerfectKidScanned?.Invoke(scannedKid);
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScanned -= OnCodeScanned;
    }
}
