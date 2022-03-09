using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FP_ControllerMovement : MonoBehaviour
{
    public float walkingSpeed = 45f;
    public float runningSpeed = 60f;
    //public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float sprintTimeLimit = 15;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    

    [HideInInspector]
    public bool canMove = true;

    [HideInInspector]
    public float sprintTimer;

    [HideInInspector]
    public bool canRun;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        sprintTimer = sprintTimeLimit;
    }

    void Update()
    {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            // Press Left Shift to run
            
            bool isRunning = canRun && sprintTimer > 0 && Input.GetKey(KeyCode.LeftShift);
            
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward + right).normalized;

            moveDirection.z *= curSpeedX;
            moveDirection.x *= curSpeedY;
         
            
            characterController.Move(moveDirection * Time.deltaTime);

            if (isRunning) {
                sprintTimer = Mathf.Max(0, sprintTimer - Time.deltaTime);
                canRun = sprintTimer > 0;
            } else {
                sprintTimer = Mathf.Min(sprintTimeLimit, sprintTimer + Time.deltaTime);
                canRun = canRun || sprintTimer >= sprintTimeLimit;
            }

    }
}