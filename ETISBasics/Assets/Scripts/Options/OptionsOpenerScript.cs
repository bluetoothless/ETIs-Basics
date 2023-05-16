using EnvControllerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsOpenerScript : MonoBehaviour
{
    public GameObject OptionsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && OptionsPanel != null)
        {
            OpenOrCloseOptions();
        }
    }

    public void OpenOrCloseOptions()
    {
        bool isPaused = EnvController.GamePaused;
        EnvController.GamePaused = !isPaused;

        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        bool isActive = OptionsPanel.activeSelf;
        OptionsPanel.SetActive(!isActive);
    }
}
