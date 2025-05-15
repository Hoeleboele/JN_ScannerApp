using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KidNameInput : MonoBehaviour 
{
    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private Button confirmButton;

    [SerializeField]
    private KidWriter writer;

    private bool isShowing = false;

    public bool IsShowing => isShowing;

    private void Awake()
    {
        confirmButton.onClick.AddListener(OnConfirmClick);
    }

    public void OnConfirmClick()
    {
        writer.AddNameToCode(inputField.text);
        gameObject.SetActive(false);
        isShowing = false;
    }

    public void ShowField()
    {
        inputField.text = string.Empty;
        isShowing = true;
        gameObject.SetActive(true);
    }
}