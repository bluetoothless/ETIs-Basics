using EnvControllerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPlayerSensorScript : MonoBehaviour
{
    private Transform Parent;

    private void Start()
    {
        Parent = gameObject.transform.parent;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Parent.GetComponentInChildren<EnemyFSMScript>().PlayerInAggroCollider = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Parent.GetComponentInChildren<EnemyFSMScript>().PlayerInAggroCollider = false;
        }
    }
}
