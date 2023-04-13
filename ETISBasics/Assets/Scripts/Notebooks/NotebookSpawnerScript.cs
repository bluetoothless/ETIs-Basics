using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotebookSpawnerScript : MonoBehaviour
{
    public Transform[] notebookSpawnLocations;
    public GameObject notebookPrefab;
    public GameObject[] notebookClones;


    void Start()
    {
        SpawnNotebooks();
    }


    void Update()
    {

    }

    void SpawnNotebooks() 
    { 
        var locationIndices = Enumerable.Range(0, notebookSpawnLocations.Length)
            .OrderBy(x => Guid.NewGuid())
            .Take(EnvController.NumberOfNotebooks)
            .ToArray();

        EnvController.Notebooks = new GameObject[EnvController.NumberOfNotebooks];

        for (int i = 0; i < EnvController.NumberOfNotebooks; i++)
        {
            EnvController.Notebooks[i] = Instantiate(notebookPrefab,
            notebookSpawnLocations[locationIndices[i]].transform.position, 
            notebookPrefab.transform.rotation/*Quaternion.Euler(0, 0, 0)*/);
        }
    }
}
