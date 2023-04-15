using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinCollisionScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            EnvController.NumberOfPosessedCoins++;
            EnvController.NumberOfCoins--;

            EnvController.Coins = EnvController.Coins
                .Where(coin => coin.transform.position != gameObject.transform.position)
                .ToArray();

            Destroy(gameObject);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }*/
}
