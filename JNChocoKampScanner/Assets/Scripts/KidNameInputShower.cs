using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidNameInputShower : MonoBehaviour
{
    [SerializeField]
    private GameObject kidNameInputField;

    private bool isShowing = false;

    public bool IsShowing => isShowing;

    public void ActivateKidNameInput()
    {
        isShowing = true;
    }

    private void Update()
    {
        if (isShowing != kidNameInputField.activeSelf)
        {
            kidNameInputField.SetActive(isShowing);
        }
    }

    public void DeactivateKidNameInput()
    {
        isShowing = false;
    }
}
