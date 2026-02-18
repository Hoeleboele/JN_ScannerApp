using System;
using UnityEngine;
using static ColorChangeChannel;

public class MiddeleeuwenScanner : MonoBehaviour
{
    [SerializeField]
    private string name;

    private void OnInCorrectKidScanned(Kid scannedKid)
    {

    }

    private void OnCorrectKidScanned(Kid scannedKid)
    {
        
    }

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCorrectKidScanned += OnCorrectKidScanned;
        Channels.ColorChangeChannel.OnInCorrectKidScanned += OnInCorrectKidScanned;
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCorrectKidScanned -= OnCorrectKidScanned;
        Channels.ColorChangeChannel.OnInCorrectKidScanned -= OnInCorrectKidScanned;
    }
}
