using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowHintScript : MonoBehaviour
{

    public GameObject NotebookHintPanel;
    public GameObject NotebookQuestionPanel;

    public void ShowHint()
    {
        NotebookHintPanel.SetActive(true);
        NotebookQuestionPanel.SetActive(false);
    }

    public void HideHint()
    {
        NotebookHintPanel.SetActive(false);
        NotebookQuestionPanel.SetActive(true);
    }
}
