using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensorScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            gameObject.GetComponentInChildren<EnemyFSMScript>().CollisionWithPlayer = true;
        }
    }
}
