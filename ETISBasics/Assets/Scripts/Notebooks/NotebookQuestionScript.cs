using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using EnvControllerNamespace;

public class NotebookQuestionScript : MonoBehaviour
{
    public GameObject GameSucceedPanel;
    public GameObject GamePanel;
    public GameObject WrongAnswer;
    public Button ButtonBackToQuestion;
    public GameObject[] NotebookQuestionPanel;
    public int whichQuestion = 0;

    public void ManageNotebookCollision()
    {
        Cursor.lockState = CursorLockMode.None;
        GamePanel.SetActive(false);
        WrongAnswer.SetActive(false);

        NotebookQuestionPanel[whichQuestion].SetActive(true);

        whichQuestion++;
        EnvController.GamePaused = true;
    }

    public void OnWrongAnswer()
    {
        WrongAnswer.SetActive(true);
        EnvController.EnemySpeed += EnvController.EnemySpeedUpStep;
    }

    public void OnCorrectAnswer()
    {
        if(EnvController.NumberOfPosessedNotebooks == 7)
            GameSucceedPanel.SetActive(true);
        else
        {
            for (int i = 0; i < NotebookQuestionPanel.Length; i++)
                NotebookQuestionPanel[i].SetActive(false);

            GamePanel.SetActive(true);
            EnvController.GamePaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}