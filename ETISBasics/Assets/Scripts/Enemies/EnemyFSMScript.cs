using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class EnemyFSMScript : MonoBehaviour
{
    [HideInInspector]
    public EnemyState CurrentState;
    [HideInInspector]
    public bool PlayerInAggroCollider;
    [HideInInspector]
    public bool PlayerInSight;
    [HideInInspector]
    public bool CollisionWithPlayer;

    private float IdleStateTime = 0;
    private float DistanceFromPlayer;
    private float MinTimeInAlertState = 5;
    private float CurrentTimeInAlertState = 0;

    private void Start()
    {
        CurrentState = EnemyState.Patrol;
        PlayerInAggroCollider = false;
        PlayerInSight = false;
        CollisionWithPlayer = false;
    }

    void FixedUpdate()
    {
        DistanceFromPlayer = Vector3.Distance(EnvController.PlayerCurrentPosition, gameObject.transform.position);

        if (!EnvController.GamePaused)
        {
            //change state if needed
            if (CollisionWithPlayer)
            {
                CurrentState = EnemyState.Idle;
                CollisionWithPlayer = false;
            }
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
                    if (PlayerInSight)
                    {
                        CurrentState = EnemyState.Chase;
                    }
                    else if (CurrentTimeInAlertState < MinTimeInAlertState)
                    {
                        CurrentTimeInAlertState += Time.deltaTime;
                    }
                    else
                    {
                        if (!PlayerInAggroCollider && !PlayerInSight)
                        {
                            CurrentState = EnemyState.Patrol;
                        }
                        CurrentTimeInAlertState = 0;
                    }
                    break;
                case EnemyState.Chase:
                    if (DistanceFromPlayer > EnvController.EnemyChaseDistance)
                    {
                        if (PlayerInAggroCollider && !PlayerInSight)
                        {
                            CurrentState = EnemyState.Alert;
                        }
                        else if (!PlayerInAggroCollider && !PlayerInSight)
                        {
                            CurrentState = EnemyState.Patrol;
                        }
                    }
                    break;
                case EnemyState.Idle:
                    if (IdleStateTime < EnvController.InvulnerabilityTime)
                    {
                        IdleStateTime += Time.deltaTime;
                    }
                    else
                    {
                        CurrentState = EnemyState.Patrol;
                        IdleStateTime = 0;
                        EnvController.PlayerInvulnerable = false;
                    }
                    break;
            }
        }
    }
}
