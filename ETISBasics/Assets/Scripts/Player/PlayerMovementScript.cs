using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float gravity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGounded;

    private void FixedUpdate()
    {
        EnvController.PlayerCurrentPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (!EnvController.GamePaused)
        {
            isGounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movementVector = transform.right * x + transform.forward * z;

            controller.Move(movementVector * EnvController.PlayerSpeed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
