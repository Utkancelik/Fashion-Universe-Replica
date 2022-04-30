using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private Animator animator;
    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (playerMovementScript.horizontalJoystickMovement != 0 || playerMovementScript.verticalJoystickMovement != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
