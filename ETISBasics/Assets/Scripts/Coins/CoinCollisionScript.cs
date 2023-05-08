using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EnvControllerNamespace;

public class CoinCollisionScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            EnvController.NumberOfPosessedCoins++;
            EnvController.NumberOfCoins--;

            EnvController.CoinLocations = EnvController.CoinLocations
                .Where(location => location != gameObject.transform.position)
                .ToArray();

            EnvController.Coins = EnvController.Coins
                .Where(coin => coin.transform.position != gameObject.transform.position)
                .ToArray();
            var ss = EnvController.Coins.Select(coin => coin.transform.position).ToArray();

            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
