using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EnvControllerNamespace;

public class HideShowHintScript : MonoBehaviour
{
    public GameObject NotebookHintPanel;
    public GameObject NotEnoughCoinsForHint;

    void Start()
    {
        if (EnvController.GamePaused == false)
            NotebookHintPanel.SetActive(false);
    }

    public void ShowHint()
    {
        if(EnvController.NumberOfPosessedCoins >= 2)
        {
            NotebookHintPanel.SetActive(true);
            EnvController.NumberOfPosessedCoins = EnvController.NumberOfPosessedCoins - 2;
        }
            
        else
            NotEnoughCoinsForHint.SetActive(true);
    }

    public void HideHint()
    {
        NotebookHintPanel.SetActive(false);
    }
}
