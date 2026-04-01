using System;
using System.Collections;
using UnityEngine;
using static ColorChangeChannel;

public class MiddeleeuwenScanner : MonoBehaviour
{
    private const float timeInBetweenHide = 2f;

    [SerializeField]
    private GameObject correctIcon, inCorrectIcon, perfectIcon;

    private void OnInCorrectKidScanned(Kid scannedKid)
    {
        inCorrectIcon.SetActive(true);
        StartCoroutine(HideAfterTime());
    }

    private void OnCorrectKidScanned(Kid scannedKid)
    {
        correctIcon.SetActive(true);
        StartCoroutine(HideAfterTime());
    }

    private void OnInPerfectKidScanned(Kid scannedKid)
    {
        perfectIcon.SetActive(true);
        StartCoroutine(HideAfterTime());
    }

    private void SetAllIconsActive(bool activeState)
    {
        correctIcon.SetActive(activeState);
        inCorrectIcon.SetActive(activeState);
        perfectIcon.SetActive(activeState);
    }

    private IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(timeInBetweenHide);

        SetAllIconsActive(false);
    }

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCorrectKidScanned += OnCorrectKidScanned;
        Channels.ColorChangeChannel.OnInCorrectKidScanned += OnInCorrectKidScanned;
        Channels.ColorChangeChannel.OnInPerfectKidScanned += OnInPerfectKidScanned;
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCorrectKidScanned -= OnCorrectKidScanned;
        Channels.ColorChangeChannel.OnInCorrectKidScanned -= OnInCorrectKidScanned;
        Channels.ColorChangeChannel.OnInPerfectKidScanned -= OnInPerfectKidScanned;
    }
}
