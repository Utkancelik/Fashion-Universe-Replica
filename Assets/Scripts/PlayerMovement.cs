using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;


    [HideInInspector] public float horizontalJoystickMovement;
    [HideInInspector] public float verticalJoystickMovement;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            JoystickMovement();
        }
        else
        {
            JoystickStop();
        }
    }

    private void JoystickStop()
    {
        horizontalJoystickMovement = 0;
        verticalJoystickMovement = 0;
    }

    private void JoystickMovement()
    {
        horizontalJoystickMovement = joystick.Horizontal;
        verticalJoystickMovement = joystick.Vertical;
        Vector3 addPos = new Vector3(horizontalJoystickMovement * speed * Time.fixedDeltaTime, 0, verticalJoystickMovement * speed * Time.fixedDeltaTime);
        transform.position += addPos;

        Vector3 direction = Vector3.forward * verticalJoystickMovement + Vector3.right * horizontalJoystickMovement;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.fixedDeltaTime);   
    }

}
