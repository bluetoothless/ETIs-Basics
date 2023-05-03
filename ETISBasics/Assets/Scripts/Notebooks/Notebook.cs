using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public GameObject[] NotebookQuestionPanel;
    public int whichQuestion = 0;

    void Start()
    {

        if (EnvController.GamePaused == false)
        {
            for (int i = 0; i < NotebookQuestionPanel.Length; i++)
                NotebookQuestionPanel[i].SetActive(false);
        }
        whichQuestion++;
    }

}
