using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class EnemyMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [HideInInspector]
    public Vector3 EnemyStartLocation;

    Vector3 velocity;
    bool isGounded;
    float x = 0.2f;
    float z = 1f;

    //patrol state
    float PatrolTimeCounter = 0;
    float PatrolTimeLength = 2;

    //alert state
    private float RotationSpeed = 100f;
    private bool RotateRight = false;
    private float MaxRotationAngle = 181f;
    private float OriginalRotationAngle;

    private void Start()
    {
        OriginalRotationAngle = transform.rotation.eulerAngles.y;
    }

    void FixedUpdate()
    {
        if (!EnvController.GamePaused && EnvController.Enemies != null && EnvController.Enemies[EnvController.Enemies.Length - 1] != null)
        {
            //gravity
            isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 movementVector = CalculateMovementVector();

            movementVector.Normalize();
            if (movementVector != Vector3.zero)
            {
                var rotationAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                OriginalRotationAngle = transform.rotation.eulerAngles.y;

                controller.Move(movementVector * EnvController.EnemySpeed * Time.deltaTime);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    Vector3 CalculateMovementVector()
    {
        var enemyFSM = gameObject.GetComponent<EnemyFSMScript>();
        switch (enemyFSM.CurrentState)
        {
            case EnemyState.Patrol:
                return CalculateForPatrolState();
            case EnemyState.Alert:
                return CalculateForAlertState();
            case EnemyState.Chase:
                return CalculateForChaseState();
            case EnemyState.Idle:
                return CalculateForIdleState();
        }
        return new Vector3(0f, 0f, 0f);
    }

    Vector3 CalculateForPatrolState()
    {
        //TODO (mo¿e) dorobiæ sprawdzenie, czy enemy jest w odleg³oœci X od EnemyStartLocation, jeœli jest daleko, to wróæ tam
        PatrolTimeCounter += Time.deltaTime;

        if (PatrolTimeCounter >= PatrolTimeLength * 2)
        {
            PatrolTimeCounter = 0;
            z = 1f;
            x = 0.2f;
        }
        else if (PatrolTimeCounter >= PatrolTimeLength)
        {
            z = -1f;
            x = -0.2f;
        }
        return new Vector3(x, 0f, z);
    }

    Vector3 CalculateForAlertState()
    {
        RotateForAlertState();
        return new Vector3(0f, 0f, 0f);
    }

    Vector3 CalculateForChaseState()
    {
        Vector3 movementVector = new Vector3(x, 0f, z);
        return movementVector;
    }

    Vector3 CalculateForIdleState()
    {
        Vector3 movementVector = new Vector3(x, 0f, z);
        return movementVector;
    }

    void RotateForAlertState()
    {
        var rotationAmount = Time.deltaTime * RotationSpeed;
        var rotationDirection = RotateRight ? 1 : -1;
        var currentAngle = transform.rotation.eulerAngles.y;
        var maxLeftAngle = OriginalRotationAngle + (MaxRotationAngle / 2);
        maxLeftAngle = maxLeftAngle >= 360f ? maxLeftAngle - 360 : maxLeftAngle;
        var maxRightAngle = maxLeftAngle - MaxRotationAngle;
        maxRightAngle = maxRightAngle < 0f ? maxRightAngle + 360 : maxRightAngle;

        transform.Rotate(0f, rotationAmount * rotationDirection, 0f);
        if ((RotateRight && currentAngle >= maxLeftAngle - 1 && currentAngle <= maxLeftAngle + 1)
            || (!RotateRight && currentAngle >= maxRightAngle - 1 && currentAngle <= maxRightAngle + 1))
        {
            RotateRight = !RotateRight;
        }
    }
}
