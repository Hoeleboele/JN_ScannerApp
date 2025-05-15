using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class KidWriter : MonoBehaviour
{
    private const string filepath = "./writer.txt";

    private List<Kid> allCodes = new List<Kid>();

    private bool scanning = false;

    private string scannedCode = string.Empty;

    [SerializeField]
    private ScanningObject scanningObject;

    [SerializeField]
    private KidNameInput nameInput;

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScannedRaw += OnCodeScannedRaw;
    }

    private void OnCodeScannedRaw(string scannedCode)
    {
        if (scanning && nameInput.IsShowing == false)
        {
            Debug.Log($"Code scanned: {scannedCode}");

            this.scannedCode = scannedCode;

            nameInput.ShowField();
        }
    }

    public void AddNameToCode(string kidName)
    {
        var kid = new Kid() { Code = scannedCode, Group=KidGroup.Maxioor, FirstName = kidName, LastName = string.Empty, IsCorrectCode = true };
        allCodes.Add(kid);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && nameInput.IsShowing == false)
        {
            scanning = !scanning;
            scanningObject.ShowScanningStatus(scanning);

            if (!scanning)
            {
                SaveKidListToFile();
            }
        }
    }

    private void SaveKidListToFile()
    {
        StringBuilder sb = new StringBuilder();

        if (File.Exists(filepath) == false)
            File.Create(filepath);

        foreach (var code in allCodes)
        {
            sb.AppendLine(code.KidToString());
        }

        File.AppendAllText(filepath, sb.ToString());

        allCodes = new List<Kid>();
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScannedRaw -= OnCodeScannedRaw;
    }
}
