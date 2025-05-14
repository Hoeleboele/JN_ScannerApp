using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFCKidLogger : MonoBehaviour
{
    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScanned += OnCodeScanned;
    }

    private void OnCodeScanned(Kid scannedKid)
    {
        Debug.Log($"Kid has been found from nfc: {scannedKid.KidToString()}");
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScanned -= OnCodeScanned;
    }
}
