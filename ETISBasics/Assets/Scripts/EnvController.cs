using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

namespace EnvControllerNamespace
{ 
    static class EnvController
    {
        public static GameObject[] Notebooks;
        public static GameObject[] Coins;
        public static GameObject[] Enemies;
        public static Vector3[] NotebookLocations;
        public static Vector3[] CoinLocations;
        public static Vector3 PlayerCurrentPosition;

        public static int NumberOfPosessedNotebooks = 0;
        public static int NumberOfPosessedCoins = 0;
        public static int LivesLeft = 3;
        public static bool GamePaused = false;
        public static bool PlayerInvulnerable = false;

        // ------------ SETTINGS ------------ //
        public static float PlayerSpeed = 600f;
        public static int NumberOfEnemies = 15;
        public static float EnemySpeed = 100f;
        public static float EnemySpeedUpStep = 72f;
        public static float EnemyChaseDistance = 1000f;
        public static float InvulnerabilityTime = 10f;
        public static float MouseSensitivity = 500f;
        public static int NumberOfNotebooks = 7;
        public static int NumberOfCoins = 25;
            // NumberOfNotebooks + NumberOfCoins should be <= 35 (number of spawn locations)
        
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

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }
}