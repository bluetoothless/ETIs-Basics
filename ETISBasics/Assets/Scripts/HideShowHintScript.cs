using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowHintScript : MonoBehaviour
{
    public GameObject NotebookHintPanel;

    void Start()
    {
        if (EnvController.GamePaused == false)
            NotebookHintPanel.SetActive(false);
    }

    public void ShowHint()
    {
        NotebookHintPanel.SetActive(true);
    }

    public void HideHint()
    {
        NotebookHintPanel.SetActive(false);
    }
}
