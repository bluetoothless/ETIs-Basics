using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnvControllerNamespace;

public class PlayerCameraScript : MonoBehaviour
{
    public Transform playerObject;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!EnvController.GamePaused) 
        { 
            float mouseX = Input.GetAxis("Mouse X") * EnvController.MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * EnvController.MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerObject.Rotate(Vector3.up * mouseX);
        }
    }
}
