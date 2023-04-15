using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotebookCollisionScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            var envControllerObj = GameObject.FindGameObjectWithTag("GameController");
            envControllerObj.gameObject.GetComponent<NotebookQuestionScript>().ManageNotebookCollision();

            PickUpNotebook();
        }
    }

    private bool AskQuestion()
    {
        return false;
    }

    private void PickUpNotebook()
    {
        EnvController.NumberOfPosessedNotebooks++;

        EnvController.NotebookLocations = EnvController.NotebookLocations
            .Where(location => location != gameObject.transform.position)
            .ToArray();

        EnvController.Notebooks = EnvController.Notebooks
            .Where(notebook => notebook.transform.position != gameObject.transform.position)
            .ToArray();

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
