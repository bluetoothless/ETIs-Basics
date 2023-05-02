using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGounded;

    int counter = 0;
    float x = 0.2f;
    float z = 1f;

    void Update()
    {
        if (!EnvController.GamePaused && EnvController.Enemies != null && EnvController.Enemies[EnvController.Enemies.Length - 1] != null)
        {
            isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            counter++;
            if (counter > 700)
            {
                z = -1f;
                x = -0.2f;
            }
            if (counter == 1400)
            {
                counter = 0;
                z = 1f;
                x = 0.2f;
            }

            Vector3 movementVector = new Vector3(x, 0f, z);
            movementVector.Normalize();

            if (movementVector != Vector3.zero)
            {
                var rotationAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);

                controller.Move(movementVector * EnvController.EnemySpeed * Time.deltaTime);
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
            }
        }
    }
}
