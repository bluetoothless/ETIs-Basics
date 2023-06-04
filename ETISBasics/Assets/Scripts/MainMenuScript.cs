using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EnvControllerNamespace;

public class MainMenuScript : MonoBehaviour
{
    public Button Options;
    public Button Quit;
    public Button BackToMenu;
    public GameObject OptionsPanel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Options.onClick.AddListener(OnOptions);
        Quit.onClick.AddListener(OnQuit);
        BackToMenu.onClick.AddListener(OnBackToMenu);
        EnvController.LivesLeft = 3;
        EnvController.NumberOfPosessedCoins = 0;
        EnvController.NumberOfPosessedNotebooks = 0;

    }

    public void OnPlay(string scena)
    {
        EnvController.GamePaused = false;
        SceneManager.LoadScene(scena);
    }

    private void OnOptions()
    {
        OptionsPanel.SetActive(true);
    }

    private void OnBackToMenu()
    {
        OptionsPanel.SetActive(false);
    }


    public void OnQuit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
