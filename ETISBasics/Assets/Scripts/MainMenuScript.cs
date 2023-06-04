using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    public void OnPlay(string scena)
    {
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
