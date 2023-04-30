using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] NotebookSpawnLocations;
    public GameObject NotebookPrefab;
    public GameObject CoinPrefab;


    void Start()
    {
        SpawnNotebooksAndCoins();
    }


    void Update()
    {

    }

    void SpawnNotebooksAndCoins() 
    { 
        var locationIndices = Enumerable.Range(0, NotebookSpawnLocations.Length)
            .OrderBy(x => Guid.NewGuid())
            .Take(EnvController.NumberOfNotebooks + EnvController.NumberOfCoins)
            .ToArray();

        EnvController.Notebooks = new GameObject[EnvController.NumberOfNotebooks];
        EnvController.Coins = new GameObject[EnvController.NumberOfCoins];

        for (int i = 0; i < EnvController.NumberOfNotebooks; i++)           //spawn notebooks
        {
            EnvController.Notebooks[i] = Instantiate(NotebookPrefab,
            NotebookSpawnLocations[locationIndices[i]].transform.position, 
            NotebookPrefab.transform.rotation/*Quaternion.Euler(0, 0, 0)*/);
        }

        for (int i = 0; i < EnvController.NumberOfCoins; i++)               //spawn coins
        {   
            EnvController.Coins[i] = Instantiate(CoinPrefab,
            NotebookSpawnLocations[locationIndices[i + EnvController.NumberOfNotebooks - 1]].transform.position,
            Quaternion.Euler(90, 0, 0));
        }
    }
}