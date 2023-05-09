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
    private float rotationSpeed = 100f;
    private bool rotateRight = false;


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
        //TODO (mo�e) dorobi� sprawdzenie, czy enemy jest w odleg�o�ci X od EnemyStartLocation, je�li jest daleko, to wr�� tam
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
        // Calculate the amount of rotation for this frame
        float rotationAmount = Time.deltaTime * rotationSpeed;

        // Determine the direction to rotate
        int rotationDirection = rotateRight ? 1 : -1;

        // Rotate the object by the specified amount and direction
        transform.Rotate(0f, rotationAmount * rotationDirection, 0f);

        // Check if we've completed a full 180 degree rotation
        var range = Mathf.Abs(transform.rotation.eulerAngles.y) % 180;
        if (range >= -5 && range <= 5)
        {
            // Switch the rotation direction
            rotateRight = !rotateRight;
        }
    }
}
