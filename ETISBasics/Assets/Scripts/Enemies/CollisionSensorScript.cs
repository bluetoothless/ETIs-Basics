using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensorScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (gameObject.transform.position.x > -6612.956 - 30 && gameObject.transform.position.x < -6612.956 + 30)
        {
            var a = 4;
        }
        if (collider.tag == "Player")
        {
            gameObject.GetComponentInChildren<EnemyFSMScript>().CollisionWithPlayer = true;
        }
    }
}
