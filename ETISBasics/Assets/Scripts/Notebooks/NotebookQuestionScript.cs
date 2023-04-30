using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotebookQuestionScript : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject NotebookQuestionPanel;
    public GameObject NotebookQuestionPanel1;
    public GameObject NotebookQuestionPanel2;
    public GameObject NotebookQuestionPanel3;
    public GameObject NotebookQuestionPanel4;
    public GameObject NotebookQuestionPanel5;
    public GameObject NotebookQuestionPanel6;
    public GameObject NotebookQuestionPanel7;
    public GameObject NotebookHintPanel;


    public void ManageNotebookCollision()
    {

        GamePanel.SetActive(false);
        NotebookHintPanel.SetActive(false);
        NotebookQuestionPanel.SetActive(false);
        EnvController.GamePaused = true;

        AskQuestion();
    }


    private void AskQuestion()
    {
        int id = 1;
        if(id == 1)
        {
            NotebookQuestionPanel1.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if(ilosc_monet==2)
            {
                //NotebookHintPanel1.SetActive(true);
            }
        }
        if (id == 2)
        {
            NotebookQuestionPanel2.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel2.SetActive(true);
            }
        }
        if (id == 3)
        {
            NotebookQuestionPanel3.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel3.SetActive(true);
            }
        }
        if (id == 4)
        {
            NotebookQuestionPanel4.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel4.SetActive(true);
            }
        }
        if (id == 5)
        {
            NotebookQuestionPanel5.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel5.SetActive(true);
            }
        }
        if (id == 6)
        {
            NotebookQuestionPanel6.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel6.SetActive(true);
            }
        }
        if (id == 7)
        {
            NotebookQuestionPanel7.SetActive(true);
            id = id + 1;
            //uzaleznic od faktycznej ilosci monet
            int ilosc_monet = 2;
            if (ilosc_monet == 2)
            {
                //NotebookHintPanel7.SetActive(true);
            }
        }
        //OnCorrectAnswer();
    }

    private void OnCorrectAnswer()
    {
        GamePanel.SetActive(true);
        NotebookQuestionPanel.SetActive(false);
        EnvController.GamePaused = false;
    }
}
