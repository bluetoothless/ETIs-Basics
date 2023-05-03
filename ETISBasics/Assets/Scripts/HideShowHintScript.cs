using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if(EnvController.NumberOfPosessedCoins >= 2)
        {
            NotebookHintPanel.SetActive(true);
            EnvController.NumberOfPosessedCoins = EnvController.NumberOfPosessedCoins - 2;
        }
            
        else
            Debug.Log("Nie masz wystarczajacej ilosci monet, aby wykupiæ podpowiedz. Koszt podpowiedzi to 2 monety");
    }

    public void HideHint()
    {
        NotebookHintPanel.SetActive(false);
    }
}
