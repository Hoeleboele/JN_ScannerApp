using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScanningObject : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpTextField;

    public void ShowScanningStatus(bool isScanning)
    {
        tmpTextField.SetText(isScanning ? "Scanning mode on" : "Scanning mode off");
        tmpTextField.gameObject.SetActive(true);
        StartCoroutine(DisableTextAfterDelay());
    }

    private IEnumerator DisableTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        tmpTextField.gameObject.SetActive(false);
    }
}
