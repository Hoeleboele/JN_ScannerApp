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
    private TMP_Dropdown dropdown;

    [SerializeField]
    private Button confirmButton;

    [SerializeField]
    private KidWriter writer;

    [SerializeField]
    private KidNameInputShower shower;

    private bool isShowing = false;

    public bool IsShowing => isShowing;

    private void OnEnable()
    {
        confirmButton.onClick.AddListener(OnConfirmClick); 
        inputField.text = string.Empty;
        isShowing = true;
    }

    private void OnDisable()
    {
        confirmButton.onClick.RemoveAllListeners();
    }

    public void OnConfirmClick()
    {
        writer.AddNameToCode(inputField.text, dropdown.options[dropdown.value].text);
        isShowing = false;
        shower.DeactivateKidNameInput();
    }
}