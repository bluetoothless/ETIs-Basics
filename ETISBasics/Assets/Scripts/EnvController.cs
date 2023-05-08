using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

namespace EnvControllerNamespace
{ 
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
        public static int LivesLeft = 3;
        public static bool GamePaused = false;

        public static int NumberOfEnemies = 15;
        public static GameObject[] Enemies;
        public static float EnemySpeed = 100;


        public static void EndTheGame(bool win)
        {
            GamePaused = true;

            if (win)
            {
                //
            }
            else
            {

            }
        }
    }

    public enum EnemyState
    {
        Patrol,
        Alert,
        Chase,
        Idle
    }
}