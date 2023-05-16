using EnvControllerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingSensorScript : MonoBehaviour
{
    //private RaycastHit Hit;
    private RaycastHit[] Hits = new RaycastHit[15];
    private Ray Ray;
    private float StartDegree;
    private float StepDegree;
    private Transform Parent;

    private int NumberOfRays = 10;

    private void Start()
    {
        StartDegree = -90.0f; //zawsze musi byc ujemne!
        StepDegree = -2 * StartDegree / (float)NumberOfRays;
        Parent = gameObject.transform.parent;
    }

    private void FixedUpdate()
    {
        if (!EnvController.GamePaused)
            CastRays();
    }

    private void CastRays()
    {
        var playerInSight = false;
        for (int i = 0; i < NumberOfRays; i++)
        {
            Ray = new Ray(gameObject.transform.position,
                gameObject.transform.TransformDirection(Quaternion.Euler
                    (0, StartDegree + StepDegree * i, 0) * Vector3.forward));
            var numberOfHits = Physics.RaycastNonAlloc(Ray, Hits);
            Array.Sort(Hits, (RaycastHit x, RaycastHit y) =>
            {
                if (x.transform == null)
                    return 2000000000;
                return x.distance.CompareTo(y.distance);
            });
            if (numberOfHits > 0)
            {
                if (Hits[0].collider.gameObject.transform.tag == "Player")
                {
                    playerInSight = true;
                }

                /*for (int j = 0; j < numberOfHits; j++)
                {
                    if (Hits[j].transform != null && Hits[j].collider.gameObject.transform.tag == "Player")
                    {
                        Parent.GetComponentInChildren<EnemyFSMScript>().PlayerInSight = true;
                    }
                }*/
            }
        }
        Parent.GetComponentInChildren<EnemyFSMScript>().PlayerInSight = playerInSight;
    }
}
