using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class KidWriter : MonoBehaviour
{
    private const string filepath = "./writer.txt";

    private List<string> allCodes = new List<string>();

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScannedRaw += OnCodeScannedRaw;
    }

    private void OnCodeScannedRaw(string scannedCode)
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log($"Code scanned: {scannedCode}");

            allCodes.Add(scannedCode);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StringBuilder sb = new StringBuilder();

            if (File.Exists(filepath) == false)
                File.Create(filepath);

            foreach (var code in allCodes)
            {
                sb.AppendLine(code);
            }

            File.WriteAllText(filepath, sb.ToString());

            allCodes = new List<string>();
        }
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScannedRaw -= OnCodeScannedRaw;
    }
}
