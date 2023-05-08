using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EnvControllerNamespace;

public class LifeLosingScript : MonoBehaviour
{
    public GameObject[] HeartsTaken;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            EnvController.LivesLeft--;
            HeartsTaken[EnvController.LivesLeft].SetActive(true);

            if (EnvController.LivesLeft == 0)
            {
                EnvController.EndTheGame(false);
            }
        }
    }
}
