using EnvControllerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPlayerSensorScript : MonoBehaviour
{
    private Transform Parent;
    private RaycastHit Hit;
    private RaycastHit[] Hits = new RaycastHit[5];
    private Ray Ray;
    private float StartDegree;
    private float StepDegree;

    private int NumberOfRays = 10;

    private void Start()
    {
        Parent = gameObject.transform.parent;
        StartDegree = -90.0f; //zawsze musi byc ujemne!
        StepDegree = -2 * StartDegree / (float)NumberOfRays;
    }

    private void FixedUpdate()
    {
        CastRays();
    }

    private void CastRays()
    {
        var playerInSight = false;
        for (int i = 0; i < NumberOfRays; i++)
        {
            Ray = new Ray(transform.position, transform.TransformDirection(Quaternion.Euler(0, StartDegree + StepDegree * i, 0) * Vector3.forward));
            var numberOfHits = Physics.RaycastNonAlloc(Ray, Hits);
            Array.Sort(Hits, (RaycastHit x, RaycastHit y) =>
                {
                    if (x.distance.IsUnityNull() || x.distance == 0)
                        return 2000000000;
                    return x.distance.CompareTo(y.distance); 
                });
            if (numberOfHits > 0)
            {
                if (Hits[0].collider.gameObject.transform.tag == "Player")
                {
                    playerInSight = true;
                }
            }
        }
        Parent.GetComponentInChildren<EnemyFSMScript>().PlayerInSight = playerInSight;
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
