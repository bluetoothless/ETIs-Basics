using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button Options;
    public Button Quit;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Options.onClick.AddListener(OnOptions);
        Quit.onClick.AddListener(OnQuit);
    }

    public void OnPlay(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    private void OnOptions()
    {
        Debug.Log("Opcje");
    }

    public void OnQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

}
