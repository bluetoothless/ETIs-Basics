using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class Notebook : MonoBehaviour
{
    public GameObject[] NotebookQuestionPanel;
    public GameObject WrongAnswer;
    public GameObject NotEnoughCoinsForHint;

    void Start()
    {

        if (EnvController.GamePaused == false)
        {
            for (int i = 0; i < NotebookQuestionPanel.Length; i++)
                NotebookQuestionPanel[i].SetActive(false);
        }

        WrongAnswer.SetActive(false);
        NotEnoughCoinsForHint.SetActive(false);
    }

}
