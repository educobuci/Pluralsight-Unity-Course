using UnityEngine;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 0f;
    public float walkingSpeed = 2f;
    public float runningSpeed = 6f;

    public float turnSpeed = 60f;
    public float turnSmoothing = 15f;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody playerRigidbody;

    // Camera reference
    private Transform cameraTransform;
    private Vector3 cameraFoward;


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float leftHorizontal = Input.GetAxisRaw("Horizontal");
        float leftVertical = Input.GetAxisRaw("Vertical");

        if (leftHorizontal != 0f || leftVertical != 0f)
        {
            speed = Input.GetButton("Run") ? runningSpeed : walkingSpeed;
            this.Move(leftHorizontal, leftVertical);
        }
        else
        {
            speed = 0f;
        }
                
        this.Animating(leftHorizontal, leftVertical);
    }

    void Move(float horizontal, float vertical)
    {
        //movement.Set(horizontal, 0f, vertical);
        //movement = movement.normalized * speed * Time.deltaTime;

        cameraFoward = Vector3.Scale(cameraTransform.forward,
            new Vector3(1, 0, 1)).normalized;
        movement = vertical * cameraFoward + horizontal * cameraTransform.right;
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);

        if (horizontal != 0f || vertical != 0f)
        {
            Rotating(horizontal, vertical);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = vertical * cameraFoward + horizontal * cameraTransform.right;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(this.GetComponent<Rigidbody>().rotation,
            targetRotation, turnSmoothing);

        this.GetComponent<Rigidbody>().MoveRotation(newRotation);
    }

    void Animating(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", speed);
    }
}
