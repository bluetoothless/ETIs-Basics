using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] notebookSpawnLocations;
    public GameObject notebookPrefab;
    public GameObject[] notebookClones;


    void Start()
    {
        SpawnObjects();
    }


    void Update()
    {
        
    }

    void SpawnObjects()
    {
        notebookClones = new GameObject[notebookSpawnLocations.Length];
        for (int i = 0; i < notebookSpawnLocations.Length; i++)
        {
            notebookClones[i] = Instantiate(notebookPrefab,
            notebookSpawnLocations[i].transform.position, 
            Quaternion.Euler(90, 0, 0));
        }
    }
}
