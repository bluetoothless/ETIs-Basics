using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class EnvController
{
    public static int NumberOfNotebooks = 7;
    public static int NumberOfCoins = 25;    // NumberOfNotebooks + NumberOfCoins should be <= 35 (number of spawn locations)
    public static GameObject[] Notebooks;
    public static GameObject[] Coins;
    public static Vector3[] NotebookLocations;
    public static Vector3[] CoinLocations;

    public static int NumberOfPosessedNotebooks = 0;
    public static int NumberOfPosessedCoins = 0;
}
