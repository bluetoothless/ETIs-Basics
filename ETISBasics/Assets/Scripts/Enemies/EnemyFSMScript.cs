using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class EnemyFSMScript : MonoBehaviour
{
    [HideInInspector]
    public EnemyState CurrentState = EnemyState.Patrol;
    [HideInInspector]
    public bool PlayerInAggroCollider = false;
    [HideInInspector]
    public bool PlayerInSight = false;
    [HideInInspector]
    public bool CollisionWithPlayer = false;

    private float EnemyCooldownTime = 10;
    private float IdleStateTime = 0;

    void FixedUpdate()
    {
        switch (CurrentState)
        {
            case EnemyState.Patrol:
                if (PlayerInAggroCollider && !PlayerInSight)
                {
                    CurrentState = EnemyState.Alert;
                }
                else if (PlayerInAggroCollider && PlayerInSight)
                {
                    CurrentState = EnemyState.Chase;
                }
                break;
            case EnemyState.Alert:
                if (PlayerInAggroCollider && PlayerInSight)
                {
                    CurrentState = EnemyState.Chase;
                }
                else if (!PlayerInAggroCollider && !PlayerInSight)
                {
                    CurrentState = EnemyState.Patrol;
                }
                break;
            case EnemyState.Chase:
                if (CollisionWithPlayer)
                {
                    CurrentState = EnemyState.Idle;
                    CollisionWithPlayer = false;
                }
                else if (!PlayerInAggroCollider && !PlayerInSight)
                {
                    CurrentState = EnemyState.Patrol;
                }
                else if (PlayerInAggroCollider && !PlayerInSight)
                {
                    CurrentState = EnemyState.Alert;
                }
                break;
            case EnemyState.Idle:
                if (IdleStateTime < EnemyCooldownTime)
                {
                    IdleStateTime += Time.deltaTime;
                }
                else
                {
                    CurrentState = EnemyState.Patrol;
                    IdleStateTime = 0;
                }
                break;
        }
    }
}
