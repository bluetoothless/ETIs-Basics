using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotebookQuestionScript : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject NotebookQuestionPanel;
    public Button CorrectAnswer;
    public Button WrongAnswer1;
    public Button WrongAnswer2;
    public Button WrongAnswer3;

    public void ManageNotebookCollision()
    {
        GamePanel.SetActive(false);
        NotebookQuestionPanel.SetActive(true);
        EnvController.GamePaused = true;
        AskQuestion();
    }

    private void AskQuestion()
    {
        CorrectAnswer.onClick.AddListener(OnCorrectAnswer);
        WrongAnswer1.onClick.AddListener(OnWrongAnswer);
        WrongAnswer2.onClick.AddListener(OnWrongAnswer);
        WrongAnswer3.onClick.AddListener(OnWrongAnswer);
    }

    private void OnWrongAnswer()
    {
        Debug.Log("Niepoprawna odpowiedz! Wrog przyspiesza!");
        AskQuestion();
    }

    private void OnCorrectAnswer()
    {
        GamePanel.SetActive(true);
        NotebookQuestionPanel.SetActive(false);
        EnvController.GamePaused = false;
    }
}
