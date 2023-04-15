using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotebookQuestionScript : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject NotebookQuestionPanel;

    public void ManageNotebookCollision()
    {
        GamePanel.SetActive(false);
        NotebookQuestionPanel.SetActive(true);
        EnvController.GamePaused = true;

        AskQuestion();
    }

    private void AskQuestion()
    {
        OnCorrectAnswer();
    }

    private void OnCorrectAnswer()
    {
        GamePanel.SetActive(true);
        NotebookQuestionPanel.SetActive(false);
        EnvController.GamePaused = false;
    }
}
