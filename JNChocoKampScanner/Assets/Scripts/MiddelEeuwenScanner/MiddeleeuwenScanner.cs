using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static ColorChangeChannel;

public class MiddeleeuwenScanner : MonoBehaviour
{
    private const float timeInBetweenHide = 2f;

    [SerializeField]
    private GameObject correctIcon, inCorrectIcon, perfectIcon;
    [SerializeField]
    private TMP_Text textField1, textField2, textField3;

    private void OnInCorrectKidScanned(Kid scannedKid)
    {
        SetTextFields(scannedKid);
        inCorrectIcon.SetActive(true);
        StartCoroutine(HideAfterTime());
    }

    private void OnCorrectKidScanned(Kid scannedKid)
    {
        SetTextFields(scannedKid);
        correctIcon.SetActive(true);
        StartCoroutine(HideAfterTime());
    }

    private void OnInPerfectKidScanned(Kid scannedKid)
    {
        SetTextFields(scannedKid);
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

    public void SetTextFields(Kid scannedKid)
    {
        textField1.text = scannedKid.FirstName;
        textField2.text = scannedKid.FirstName;
        textField3.text = scannedKid.FirstName;
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
