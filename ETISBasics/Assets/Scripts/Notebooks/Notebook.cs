using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public GameObject NotebookQuestionPanel;
    public GameObject NotebookQuestionPanel1;
    public GameObject NotebookQuestionPanel2;
    public GameObject NotebookQuestionPanel3;
    public GameObject NotebookQuestionPanel4;
    public GameObject NotebookQuestionPanel5;
    public GameObject NotebookQuestionPanel6;
    public GameObject NotebookQuestionPanel7;
    public GameObject NotebookHintPanel;
    public int whichQuestion = 1;

    void Start()
    {
        if(EnvController.GamePaused == false)
        {
            NotebookQuestionPanel.SetActive(false);
            NotebookQuestionPanel1.SetActive(false);
            NotebookQuestionPanel2.SetActive(false);
            NotebookQuestionPanel3.SetActive(false);
            NotebookQuestionPanel4.SetActive(false);
            NotebookQuestionPanel5.SetActive(false);
            NotebookQuestionPanel6.SetActive(false);
            NotebookQuestionPanel7.SetActive(false);
            NotebookHintPanel.SetActive(false);
        }
        else
        {
            NotebookQuestionPanel.SetActive(true);

            if(whichQuestion == 1)
                NotebookQuestionPanel1.SetActive(true);
            else if(whichQuestion == 2)
                NotebookQuestionPanel2.SetActive(true);
            else if(whichQuestion == 3)
                NotebookQuestionPanel3.SetActive(true);
            else if(whichQuestion == 4)
                NotebookQuestionPanel4.SetActive(true);
            else if(whichQuestion == 5)
                NotebookQuestionPanel5.SetActive(true);
            else if(whichQuestion == 6)
                NotebookQuestionPanel6.SetActive(true);
            else if(whichQuestion == 7)
                NotebookQuestionPanel7.SetActive(true);

            whichQuestion++;
        }
    }

}
