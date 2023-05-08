using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EnvControllerNamespace;

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
            .Where(location => IsNotAroundTheSameLocation(location, gameObject.transform.position))
            .ToArray();

        EnvController.Notebooks = EnvController.Notebooks
        .Where(notebook => IsNotAroundTheSameLocation(notebook.transform.position, gameObject.transform.position))
            .ToArray();

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    private bool IsNotAroundTheSameLocation(Vector3 location, Vector3 currentLocation)
    {
        var approxVectorX = new Vector3(30f, 0f, 0f);
        var approxVectorZ = new Vector3(0f, 0f, 30f);
        var isAround = (location - approxVectorX).x  <= currentLocation.x && (location + approxVectorX).x >= currentLocation.x
            && (location - approxVectorZ).z <= currentLocation.z && (location + approxVectorZ).z >= currentLocation.z;
        return !isAround;
    }
}
