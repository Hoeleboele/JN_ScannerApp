using Assets.Scripts.NFC_scanner;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button scannerMenuButton;
    [SerializeField]
    private Button scoreBoardMenuButton;
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button closeAppButton;

    private void Awake()
    {
        scannerMenuButton.onClick.AddListener(OpenScannerMenu);
        scoreBoardMenuButton.onClick.AddListener(OpenScoreBoardMenu);
        mainMenuButton.onClick.AddListener(OpenMainMenu);
        closeAppButton.onClick.AddListener(CloseApplication);
    }

    private void OpenScoreBoardMenu()
    {
        SceneManager.LoadScene(2);
    }

    private void OpenScannerMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CloseApplication()
    {
        CardReader.CloseApp();
        Application.Quit();
    }
}
