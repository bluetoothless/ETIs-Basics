using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NotebookSpinnerScript : MonoBehaviour
{
    public int spinSpeed;
    private bool locationsSaved = false;

    void FixedUpdate()
    {
        if (EnvController.Notebooks != null)
        {
            if (!locationsSaved)
            {
                EnvController.NotebookLocations = new Vector3[EnvController.NumberOfNotebooks];
                for (int i = 0; i < EnvController.NumberOfNotebooks; i++)
                {
                    EnvController.NotebookLocations[i] = EnvController.Notebooks[i].transform.position;
                }
                locationsSaved = true;
            }

            int j = 0;
            foreach (GameObject notebook in EnvController.Notebooks)
            {
                //notebook.transform.Rotate(0, spinSpeed * Time.fixedDeltaTime, 0, Space.World);
                notebook.transform.RotateAround(EnvController.NotebookLocations[j] - new Vector3(14.2934f, 0, 0), Vector3.up, spinSpeed * Time.fixedDeltaTime);
                j++;
            }
        }
    }
}
