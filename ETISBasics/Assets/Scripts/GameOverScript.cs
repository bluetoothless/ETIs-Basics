using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EnvControllerNamespace;

public class GameOverScript : MonoBehaviour
{
    public Button RestartGame;
    public Button BackToMenu;
    public Button ExitGame;

    void Start()
    {
        ExitGame.onClick.AddListener(OnQuit);
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnRestartGame(string scena)
    {
        EnvController.GamePaused = false;
        EnvController.LivesLeft = 3;
        EnvController.NumberOfPosessedCoins = 0;
        EnvController.NumberOfPosessedNotebooks = 0;
        SceneManager.LoadScene(scena);

    }

    public void OnBackToMenu(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void OnQuit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
