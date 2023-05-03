using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotebookQuestionScript : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject[] NotebookQuestionPanel;
    public int whichQuestion = 0;


    public void ManageNotebookCollision()
    {
        Cursor.lockState = CursorLockMode.None;
        GamePanel.SetActive(false);

        for (int i = 0; i < NotebookQuestionPanel.Length; i++)
        {
            if (whichQuestion == i)
                NotebookQuestionPanel[i].SetActive(true);
        }

        whichQuestion++;
        EnvController.GamePaused = true;
    }


    public void OnWrongAnswer()
    {
        Debug.Log("Niepoprawna odpowiedz! Wrog przyspiesza!");
    }


    public void OnCorrectAnswer()
    {
        for (int i = 0; i < NotebookQuestionPanel.Length; i++)
            NotebookQuestionPanel[i].SetActive(false);

        GamePanel.SetActive(true);
        EnvController.GamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}